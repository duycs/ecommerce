using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Infrastructure;
using ECommerce.Shared.Dotnet.Specifications;
using EventBus.Abstractions;
using Integration.Events.OrderEvents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Services.IntegratedEventHandlers
{
    public class OrderCancelledEventHandler : IIntegrationEventHandler<OrderCancelledIntegratedEvent>
    {
        private readonly IProductRepository _productRepository;
        private readonly IECommerceUnitOfWork _uow;

        public OrderCancelledEventHandler(IProductRepository productRepository, IECommerceUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        public async Task Handle(OrderCancelledIntegratedEvent @event)
        {
            var details = @event.Details;
            var childProductIds = details.Select(s => s.ProductChildId).ToList();
            var childProducts = await _productRepository.GetChidren(new Specification<ProductChild>(a => childProductIds.Contains(a.Id)));
            bool saveFailed;
            Guid? conflictId = null;
            do
            {
                saveFailed = false;
                foreach (var detail in details)
                {
                    var childProduct = childProducts.FirstOrDefault(a => a.Id == detail.ProductChildId);
                    if (childProduct == null || (conflictId.HasValue && conflictId.Value != childProduct.Id)) continue;
                    childProduct.AddQuantity(detail.Quantity);
                    _productRepository.UpdateChild(childProduct);
                }
                conflictId = null;
                try
                {
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    var entry = ex.Entries.Single();
                    await entry.ReloadAsync();
                    conflictId = ((ProductChild)entry.Entity).Id;
                }
                catch (Exception)
                {
                    throw;
                }
            } while (saveFailed);
        }
    }
}
