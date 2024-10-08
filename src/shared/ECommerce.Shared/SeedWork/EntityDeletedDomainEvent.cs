using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.SeedWork
{
    public class EntityDeletedDomainEvent : INotification
    {
        public Guid Id { get; private set; }

        public Type EntityType { get; private set; }

        public EntityDeletedDomainEvent(Guid id, Type entityType)
        {
            Id = id;
            EntityType = entityType;
        }
    }
}
