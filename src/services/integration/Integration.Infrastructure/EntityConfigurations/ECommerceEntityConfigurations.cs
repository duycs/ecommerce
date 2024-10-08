using ECommerce.Shared.SeedWork;
using Integration.Domain.ECommerceAggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integration.Infrastructure.EntityConfigurations
{
    public class ProductEntityConfiguration : EntityConfiguration<Product>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products", "public", t => t.ExcludeFromMigrations());
        }
    }

    public class ProductChildEntityConfiguration : EntityConfiguration<ProductChild>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductChild> builder)
        {
            builder.ToTable("product_children", "public", t => t.ExcludeFromMigrations());
        }
    }

    public class CustomerEntityConfiguration : EntityConfiguration<Customer>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers", "public", t => t.ExcludeFromMigrations());
        }
    }
}
