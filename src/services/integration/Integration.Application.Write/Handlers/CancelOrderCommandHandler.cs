using Dapper;
using ECommerce.Shared.Exceptions;
using Integration.Application.Write.Commands;
using Integration.Domain.ECommerceAggregateModels;
using Integration.Domain.OrderAggregateModels;
using Integration.Infrastructure;
using MediatR;
using System;
using System.Linq;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Shared.Extensions;
using Integration.Domain.AggregateModels.SystemLogAggregate;
using Integration.Domain.Enums;
using ECommerce.Shared.Dotnet.Specifications;

namespace Integration.Application.Write.Handlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IDbConnection _db;
        private readonly IProductChildRepository _productChildRepository;
        private readonly IECommerceUnitOfWork _ecomUow;
        private readonly IOrderRepository _orderRepository;
        private readonly ISystemLogRepository _systemLogRepository;

        public CancelOrderCommandHandler(IDbConnection db, IProductChildRepository productChildRepository, IECommerceUnitOfWork ecomUow, IOrderRepository orderRepository, ISystemLogRepository systemLogRepository)
        {
            _db = db;
            _productChildRepository = productChildRepository;
            _ecomUow = ecomUow;
            _orderRepository = orderRepository;
            _systemLogRepository = systemLogRepository;
        }

        public async Task<Unit> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            SystemLog systemLog = new SystemLog("CancelOrderCommandHandler", StatusLog.Successed.Id);
            systemLog.AddContentLog("request", request);

            var mapping = await _db.QueryFirstOrDefaultAsync<Guid?>(@"select order_id from integration.order_mappings where old_id = @Id limit 1", new
            {
                Id = Convert.ToInt32(request.OrderId),
            });
            if (!mapping.HasValue)
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoOrderMappingFound);
                throw new BusinessRuleException(ECommerceBusinessRule.NoOrderMappingFound);
            }
            var order = await _orderRepository.GetByIdAsync(mapping.Value);
            if (order == null)
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoOrderFound);
                throw new BusinessRuleException(ECommerceBusinessRule.NoOrderFound);
            }
            var childProductIds = order.Details.Select(x => x.ProductChildId).ToList();
            var childProducts = await _productChildRepository.GetManyAsync(new Specification<ProductChild>(a => childProductIds.Contains(a.Id)));
            foreach (var detail in order.Details)
            {
                var childProduct = childProducts.FirstOrDefault(a => a.Id == detail.ProductChildId);
                if (childProduct == null) continue;
                childProduct.AddQuantity(detail.Quantity);
                _productChildRepository.Update(childProduct);
            }
            order.Cancel();
            _orderRepository.Update(order);
            _systemLogRepository.Add(systemLog);
            try
            {
                await _ecomUow.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                await LogErrorDB(systemLog, "DBConcurrencyException", ECommerceBusinessRule.QuantityUpdated);
                throw new BusinessRuleException(ECommerceBusinessRule.QuantityUpdated);
            }
            catch (Exception ex)
            {
                await LogErrorDB(systemLog, "Exception", ex);
                throw ex;
            }
            return Unit.Value;
        }

        private async Task LogErrorDB(SystemLog systemLog, string nameError, object contentError)
        {
            systemLog.AddContentLog(nameError, contentError);
            systemLog.SetStatus(StatusLog.Failed.Id);
            _systemLogRepository.Add(systemLog);

            await _ecomUow.SaveChangesAsync();
        }
    }
}
