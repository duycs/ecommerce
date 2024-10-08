using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Synchronize.Domain.EComAggregate;

namespace Synchronize.Infrastructure.EntityConfigurations
{
    public class ProductAttributeEntityConfiguration : EntityConfiguration<ProductAttribute>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.HasOne(p => p.Product)
                .WithOne()
                .HasForeignKey<ProductAttribute>(p => p.ProductId);
            builder.Property(a => a.Name)
                .IsRequired();

            builder.Property(a => a.Priority).HasDefaultValue(0);
            builder.HasMany(a => a.ProductAttributeValues).WithOne(a => a.ProductAttribute).HasForeignKey(a => a.AttributeId);
        }
    }
}
