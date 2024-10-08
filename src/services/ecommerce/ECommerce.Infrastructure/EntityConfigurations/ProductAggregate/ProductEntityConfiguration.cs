using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.ProductAggregate
{
    public class ProductEntityConfiguration : EntityConfiguration<Product>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.Property(a => a.ShopId).IsRequired();

            builder.Property(a => a.Sku).IsRequired();

            builder.Property(a => a.Name).IsRequired();

            builder.Property(a => a.CategoryId).IsRequired();

            builder.Property(a => a.IsSellFullSize).IsRequired();

            builder.HasOne(a => a.Category)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.CategoryId);

            builder.HasOne(a => a.Brand)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.ProductPrices)
                .WithOne(a => a.ParentProduct)
                .HasForeignKey(a => a.ProductId);

            builder.HasGeneratedTsVectorColumn(a => a.SearchVector,
                    "english",
                    a => new {a.Name, a.Sku})
                .HasIndex(a => a.SearchVector)
                .HasMethod("GIN");

            builder.HasMany(a => a.Attributes)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId);
        }
    }
}
