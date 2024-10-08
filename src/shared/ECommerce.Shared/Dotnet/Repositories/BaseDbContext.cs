using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.Shared.Dotnet.Repositories
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext()
        {
        }

        protected BaseDbContext(DbContextOptions options)
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
