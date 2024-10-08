using Microsoft.AspNetCore.Identity;
using System;

namespace ECommerce.Shared.SeedWork
{
    public abstract class BaseRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
