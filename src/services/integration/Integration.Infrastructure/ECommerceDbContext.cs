using ECommerce.Shared.Dotnet.Repositories;
using Integration.Domain.AggregateModels;
using Integration.Domain.AggregateModels.SystemLogAggregate;
using Integration.Domain.ECommerceAggregateModels;
using Integration.Domain.OrderAggregateModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Integration.Infrastructure
{
    public class ECommerceDbContext : BaseDbContext
    {
        public static string SchemaName = "integration";

        // public
        public virtual DbSet<ProductChild> ProductChildren { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        // order
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        // integration
        public virtual DbSet<AttributeMapping> AttributeMappings { get; set; }
        public virtual DbSet<BrandMapping> BrandMappings { get; set; }
        public virtual DbSet<CategoryMapping> CategoryMappings { get; set; }
        public virtual DbSet<CustomerMapping> CustomerMappings { get; set; }
        public virtual DbSet<OrderMapping> OrderMappings { get; set; }
        public virtual DbSet<ProductMapping> ProductMappings { get; set; }
        public virtual DbSet<ChildProductMapping> ChildProductMappings { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public ECommerceDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override string GetMigrationSchema()
        {
            return SchemaName;
        }
    }
}
