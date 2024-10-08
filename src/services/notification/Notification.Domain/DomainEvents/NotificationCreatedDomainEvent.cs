using MediatR;
using Notification.Domain.AggregateModels.NotificationAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Domain.DomainEvents
{
    public class NotificationCreatedDomainEvent : INotification
    {
        public NotificationHistory Notification { get; private set; }

        public NotificationCreatedDomainEvent(NotificationHistory notification)
        {
            Notification = notification;
        }
    }
}
