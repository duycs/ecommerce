using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Identity.Domain.AccountAggregate
{
    public class Account : BaseAccount
    {
        public virtual ICollection<AccountRole> UserRoles { get; } = new Collection<AccountRole>();

        protected Account() : base() { }
        public Account(string userName, bool isActive, string firstName, string lastName) : base(userName, isActive, firstName, lastName)
        {
            MarkCreated();
        }

        public Account(Guid id, string userName, bool isActive, string firstName, string lastName) : this(userName, isActive, firstName, lastName)
        {
            Id = id;
        }

        public void Update(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
