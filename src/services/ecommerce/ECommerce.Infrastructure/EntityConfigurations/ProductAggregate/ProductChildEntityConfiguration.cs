using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.ProductAggregate
{
    public class ProductChildEntityConfiguration : EntityConfiguration<ProductChild>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductChild> builder)
        {
            builder.HasIndex(a => a.Sku).IsUnique();
            builder.Property(a => a.QuantityInStock)
                    .IsRequired()
                    .IsConcurrencyToken()
                    .HasDefaultValue(0);
            builder.HasOne(a => a.Product)
                .WithMany(a => a.Children)
                .HasForeignKey(a => a.ProductId);
            builder.Ignore(a => a.AttributeValues);
        }
    }
}
