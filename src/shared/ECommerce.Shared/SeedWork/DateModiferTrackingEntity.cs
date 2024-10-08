using ECommerce.Shared.Dotnet.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Shared.SeedWork
{
    public abstract class DateModiferTrackingEntity : ModifierTrackingEntity, IDateTrackingEntity
    {
        public DateTimeOffset CreatedDate { get; private set; }

        public DateTimeOffset LastUpdatedDate { get; private set; }

        public void MarkCreated()
        {
            CreatedDate = DateTimeOffset.UtcNow;
            LastUpdatedDate = DateTimeOffset.UtcNow;
        }

        public void MarkUpdated()
        {
            LastUpdatedDate = DateTimeOffset.UtcNow;
        }
    }
    public abstract class ModifierTrackingEntity : Entity, IModifierTrackingEntity, IEntity
    {
        public string CreatedBy { get; private set; }

        public Guid CreatedById { get; private set; }

        public string LastUpdatedBy { get; private set; }

        public Guid LastUpdatedById { get; private set; }

        public void MarkCreated(Guid authorId, string authorName)
        {
            CreatedBy = authorName;
            LastUpdatedBy = authorName;
            CreatedById = authorId;
            LastUpdatedById = authorId;
        }

        public void MarkModified(Guid authorId, string authorName)
        {
            if (authorId != Guid.Empty && !string.IsNullOrEmpty(authorName))
            {
                LastUpdatedBy = authorName;
                LastUpdatedById = authorId;
            }
        }
    }
    public abstract class Entity : IEntity, IChangeTrackingEntity
    {
        private int? _requestedHashCode;

        private List<INotification> _domainEvents;

        public Guid Id { get; set; }

        [NotMapped]
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public bool IsTransient()
        {
            return Id == default(Guid);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            Entity entity = (Entity)obj;
            if (entity.IsTransient() || IsTransient())
            {
                return false;
            }

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                {
                    _requestedHashCode = Id.GetHashCode() ^ 0x1F;
                }

                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return left?.Equals(right) ?? object.Equals(right, null);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class PredefinedObjectAttribute : Attribute
    {
    }
    public abstract class DateTrackingEntity : Entity, IDateTrackingEntity, IEntity
    {
        public DateTimeOffset CreatedDate { get; private set; }

        public DateTimeOffset LastUpdatedDate { get; private set; }

        public void MarkCreated()
        {
            CreatedDate = DateTimeOffset.UtcNow;
            LastUpdatedDate = DateTimeOffset.UtcNow;
        }

        public void MarkUpdated()
        {
            LastUpdatedDate = DateTimeOffset.UtcNow;
        }
    }

}
