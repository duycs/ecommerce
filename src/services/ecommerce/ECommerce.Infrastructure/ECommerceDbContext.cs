using ECommerce.Domain.AggregateModels.BrandAggregate;
using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Domain.AggregateModels.ProductCategoryAggregate;
using ECommerce.Domain.AggregateModels.ShopAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ECommerce.Domain.AggregateModels.ProductAttributeAggregate;
using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Domain.AggregateModels.LocationAggregate;
using ECommerce.Domain.AggregateModels.SystemConfigurationAggregate;
using ECommerce.Shared.Dotnet.Repositories;

namespace ECommerce.Infrastructure
{
    public class ECommerceDbContext : BaseDbContext
    {
        public static string SchemaName => "public";

        public virtual DbSet<Province>Provinces { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Ward> Wards { get; set; } 
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopBankAccount> ShopBankAccounts { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductChild> ProductChildren { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<BestSellingProduct> BestSellingProducts { get; set; }
        public virtual DbSet<NewProduct> NewProducts { get; set; }
        public virtual DbSet<SuggestProduct> SuggestProducts { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<SystemConfiguration> SystemConfigurations { get; set; }
        
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public ECommerceDbContext()
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
