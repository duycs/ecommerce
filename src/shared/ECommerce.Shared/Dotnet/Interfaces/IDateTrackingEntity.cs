using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Dotnet.Interfaces
{
    public interface IDateTrackingEntity
    {
        DateTimeOffset CreatedDate { get; }

        DateTimeOffset LastUpdatedDate { get; }

        void MarkCreated();

        void MarkUpdated();
    }
    public interface IModifierTrackingEntity : IEntity
    {
        string CreatedBy { get; }

        Guid CreatedById { get; }

        string LastUpdatedBy { get; }

        Guid LastUpdatedById { get; }

        void MarkCreated(Guid authorId, string authorName);

        void MarkModified(Guid authorId, string authorName);
    }
    public interface IEntity
    {
        Guid Id { get; set; }
    }
    public interface IChangeTrackingEntity
    {
        IReadOnlyCollection<INotification> DomainEvents { get; }

        void ClearDomainEvents();

        void AddDomainEvent(INotification eventItem);
    }
}
