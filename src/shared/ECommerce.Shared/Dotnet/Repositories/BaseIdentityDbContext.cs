using ECommerce.Shared.SeedWork;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ECommerce.Shared.Dotnet.Repositories
{
    public abstract class BaseIdentityDbContext<TUser, TRole> : IdentityDbContext<TUser, TRole, Guid> where TUser : BaseAccount where TRole : BaseRole
    {
        protected BaseIdentityDbContext()
        {
        }

        protected BaseIdentityDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected abstract string GetMigrationSchema();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
