using ECommerce.Application.Write.Commands.Carts;
using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Infrastructure;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using EventBus.Abstractions;
using Integration.Events.CustomerEvents;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Write.CommandHandlers.Carts
{
    public class OrderCommandHandler : IRequestHandler<OrderCommand, Guid>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IECommerceUnitOfWork _uow;
        private readonly IEventBus _eventBus;

        public OrderCommandHandler(ICartRepository cartRepository,
            ICustomerRepository customerRepository,
            IECommerceUnitOfWork uow,
            IEventBus eventBus)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _eventBus = eventBus;
            _uow = uow;
        }

        public async Task<Guid> Handle(OrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            var cart = await _cartRepository.GetSingleAsync(CartSpecs.GetByCustomerId(request.CustomerId));
            if (cart == null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.NoCartFound);
            }

            if (!cart.CartDetails.Any())
                throw new BusinessRuleException(ECommerceBusinessRule.NotItemsInCart);
            
            var eventModel = cart.To<CustomerOrderedIntegratedEvent>();

            if(request.AddressId.HasValue)
            {
                var address = customer?.GetAddress(request.AddressId.Value);
                if (address == null)
                {
                    throw new BusinessRuleException(ECommerceBusinessRule.AddressNotFound);
                }
                eventModel = address.To(eventModel);
            }
            else
            {
                var address = customer?.GetAddressDefault();
                if (address == null)
                {
                    throw new BusinessRuleException(ECommerceBusinessRule.AddressNotFound);
                }
                eventModel = address.To(eventModel);
            }

            var orderId = Guid.NewGuid();
            eventModel.OrderId = orderId;
            
            cart.Order();
            await _uow.SaveChangesAsync();
            _eventBus.Publish(eventModel);
            return eventModel.OrderId;
        }
    }
}
