using ECommerce.Shared.Exceptions;
using MediatR;
using Order.Application.Write.Commands.Orders;
using Order.Domain.AggregateModels.OrderAggregate;
using Order.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Integration.Events.OrderEvents;
using EventBus.Abstractions;
using ECommerce.Shared.Extensions;

namespace Order.Application.Write.CommandHandlers.Orders
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly ICustomerOrderRepository _orderRepository;
        private readonly IOrderUnitOfWork _uow;
        private readonly IEventBus _eventBus;

        public CancelOrderCommandHandler(ICustomerOrderRepository orderRepository, IOrderUnitOfWork uow, IEventBus eventBus)
        {
            _orderRepository = orderRepository;
            _uow = uow;
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
                throw new BusinessRuleException(ECommerceBusinessRule.NoOrderFound);
            var eventModel = order.To<OrderCancelledIntegratedEvent>();

            order.Cancel();

            _orderRepository.Update(order);

            await _uow.SaveChangesAsync();

            _eventBus.Publish(eventModel);

            return Unit.Value;
        }
    }
}
