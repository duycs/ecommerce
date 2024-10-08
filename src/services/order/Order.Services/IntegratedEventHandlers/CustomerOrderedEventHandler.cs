using EventBus.Abstractions;
using Integration.Events.CustomerEvents;
using Integration.Events.OrderEvents;
using Order.Domain.AggregateModels.OrderAggregate;
using Order.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Services.IntegratedEventHandlers
{
    public class CustomerOrderedEventHandler : IIntegrationEventHandler<CustomerOrderedIntegratedEvent>
    {
        private readonly ICustomerOrderRepository _customerOrderRepository;
        private readonly IOrderUnitOfWork _uow;
        private readonly IEventBus _eventBus;

        public CustomerOrderedEventHandler(ICustomerOrderRepository customerOrderRepository, IOrderUnitOfWork uow, IEventBus eventBus)
        {
            _customerOrderRepository = customerOrderRepository;
            _uow = uow;
            _eventBus = eventBus;
        }

        public async Task Handle(CustomerOrderedIntegratedEvent @event)
        {
            var details = @event.Details.Select(a =>
            {
                var detail = new OrderDetail(a.Quantity, a.Price, a.DiscountPrice, a.ProductId, a.ProductSku, a.ProductName, a.ProductImage, a.ProductChildId, a.ProductChildName, a.ProductChildSku, a.BrandId, a.BrandName, a.ProductCategoryId, a.ProductCategoryName, a.ShopId, a.ShopName);

                var attributeValues = a.AttributeValues.Select(b => new ProductAttributeValue(b.Id, b.Code, b.Name, b.Value, b.AttributeName, b.Priority));

                detail.AddAttributeValues(attributeValues);
                return detail;
            });

            var order = new CustomerOrder(@event.OrderId, @event.CustomerId, @event.CustomerName, @event.CustomerPhone, @event.CustomerAddress, @event.ProvinceId, @event.ProvinceName,
                @event.DistrictId, @event.DistrictName, @event.WardId, @event.WardName, @event.DiscountPrice, @event.Note, @event.CreationDate);
            order.AddDetails(details);

            _customerOrderRepository.Add(order);
            await _uow.SaveChangesAsync();

            _eventBus.Publish(new OrderCreatedIntegratedEvent()
            {
                OrderId = order.Id
            });
        }
    }
}
