using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Synchronize.Domain.EComAggregate;

namespace Synchronize.Infrastructure.EntityConfigurations
{
    public class ProductChildEntityConfiguration : EntityConfiguration<ProductChild>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductChild> builder)
        {
            builder.HasOne(a => a.Product).WithMany(a => a.Children).HasForeignKey(a => a.ProductId);
            builder.HasMany(a => a.ProductPrices).WithOne().HasForeignKey(a => a.ProductChildId);
            builder.HasIndex(a => a.Sku).IsUnique();
            builder.Property(a => a.QuantityInStock)
                    .IsRequired()
                    .HasDefaultValue(0);
        }
    }
}
