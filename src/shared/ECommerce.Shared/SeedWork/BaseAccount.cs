using ECommerce.Shared.Dotnet.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ECommerce.Shared.SeedWork
{
    public abstract class BaseAccount : IdentityUser<Guid>, IBaseAccount, IDateTrackingEntity, IModifierTrackingEntity, IEntity, IAggregateRoot
    {
        public bool IsActive { get; private set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string CreatedBy { get; private set; }

        public Guid CreatedById { get; private set; }

        public string LastUpdatedBy { get; private set; }

        public Guid LastUpdatedById { get; private set; }

        public DateTimeOffset CreatedDate { get; private set; }

        public DateTimeOffset LastUpdatedDate { get; private set; }

        public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; } = new Collection<IdentityUserClaim<Guid>>();


        protected BaseAccount()
        {
        }

        public BaseAccount(string userName, bool isActive, string firstName, string lastName)
        {
            UserName = userName;
            IsActive = isActive;
            FirstName = firstName;
            LastName = lastName;
        }

        public void MarkCreated(Guid authorId, string authorName)
        {
            CreatedBy = authorName;
            LastUpdatedBy = authorName;
            CreatedById = authorId;
            LastUpdatedById = authorId;
        }

        public void MarkCreated()
        {
            CreatedDate = DateTimeOffset.UtcNow;
            LastUpdatedDate = DateTimeOffset.UtcNow;
        }

        public void MarkModified(Guid authorId, string authorName)
        {
            if (authorId != Guid.Empty && !string.IsNullOrEmpty(authorName))
            {
                LastUpdatedBy = authorName;
                LastUpdatedById = authorId;
            }
        }

        public void MarkUpdated()
        {
            LastUpdatedDate = DateTimeOffset.UtcNow;
        }

        public void Active()
        {
            IsActive = true;
        }

        public void Disable()
        {
            IsActive = false;
        }
    }
}
