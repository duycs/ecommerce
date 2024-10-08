using ECommerce.Shared.Dotnet.Repositories;
using Microsoft.EntityFrameworkCore;
using Order.Domain.AggregateModels.OrderAggregate;
using System.Reflection;

namespace Order.Infrastructure
{
    public class OrderDbContext : BaseDbContext
    {
        public static string SchemaName => "order";

        public virtual DbSet<CustomerOrder> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public OrderDbContext()
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
