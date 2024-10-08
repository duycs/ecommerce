﻿using EventBus.Abstractions;
using Integration.Domain.DomainEvents;
using Integration.Events.OrderEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Integration.Api.DomainEventHandlers
{
    public class OrderStatusChangedDomainEventHandler : INotificationHandler<OrderStatusChangedDomainEvent>
    {
        private readonly IEventBus _eventBus;

        public OrderStatusChangedDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(OrderStatusChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new OrderStatusChangedIntegratedEvent()
            {
                OrderId = notification.OrderId,
                SaasCode = notification.SaasCode,
                LastStatus = notification.LastStatus.Id,
                CurrentStatus = notification.CurrentStatus.Id,
                UserId = notification.CustomerId
            });
            return Task.CompletedTask;
        }
    }
}
