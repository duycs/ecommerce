using ECommerce.Shared.Dotnet.Repositories;
using Microsoft.EntityFrameworkCore;
using Synchronize.Domain.EComAggregate;
using Synchronize.Domain.IntegrationAggregate;
using Synchronize.Domain.OrderAggregate;
using System;
using System.Reflection;

namespace Synchronize.Infrastructure
{
    public class ECommerceDbContext : BaseDbContext
    {
        // public
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ProductChild> ProductChildren { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

        // integration
        public virtual DbSet<ChildProductMapping> ChildProductMappings { get; set; }
        public virtual DbSet<ProductMapping> ProductMappings { get; set; }
        public virtual DbSet<AttributeMapping> AttributeMappings { get; set; }

        // order
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

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
            throw new NotImplementedException();
        }
    }
}
