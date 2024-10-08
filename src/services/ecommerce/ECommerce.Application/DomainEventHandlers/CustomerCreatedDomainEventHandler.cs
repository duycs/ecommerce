using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Domain.AggregateModels.ShopAggregate;
using ECommerce.Domain.DomainEvents;
using ECommerce.Infrastructure;
using EventBus.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Events
{
    public class CustomerCreatedDomainEventHandler : INotificationHandler<CustomerCreatedDomainEvent>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IECommerceUnitOfWork _uow;

        public CustomerCreatedDomainEventHandler(ICartRepository cartRepository, IECommerceUnitOfWork uow)
        {
            _cartRepository = cartRepository;
            _uow = uow;
        }

        public Task Handle(CustomerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var cart = new Cart(notification.Customer.Id);
            _cartRepository.Add(cart);
            return Task.CompletedTask;
        }
    }
}
