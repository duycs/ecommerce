using ECommerce.Shared.Dotnet.Repositories;
using Identity.Domain.AccountAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Identity.Infrastructure
{
    public class ECommerceIdentityDbContext : BaseIdentityDbContext<Account, Role>
    {
        public const string SchemaName = "identity";

        public ECommerceIdentityDbContext(DbContextOptions<ECommerceIdentityDbContext> options) : base(options)
        {
        }

        public ECommerceIdentityDbContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(SchemaName);
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override string GetMigrationSchema()
        {
            return SchemaName;
        }
    }
}
