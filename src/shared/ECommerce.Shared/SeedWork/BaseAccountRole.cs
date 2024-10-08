using Microsoft.AspNetCore.Identity;
using System;

namespace ECommerce.Shared.SeedWork
{
    public abstract class BaseAccountRole<TAccount, TRole> : IdentityUserRole<Guid> where TAccount : BaseAccount where TRole : BaseRole
    {
        public virtual TRole Role { get; private set; }

        public virtual TAccount Account { get; private set; }
    }
}
