using ECommerce.Domain.AggregateModels.ProductAttributeAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.ProductAttributeAggregate
{
    public class ProductAttributeValueEntityConfiguration : EntityConfiguration<ProductAttributeValue>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.Property(a => a.AttributeId).IsRequired();

            builder.Property(a => a.Code).IsRequired();

            builder.Property(a => a.Name).IsRequired();

            builder.Property(a => a.Priority).HasDefaultValue(0);

            builder.HasOne(a => a.ProductAttribute)
                    .WithMany(a => a.ProductAttributeValues)
                    .HasForeignKey(a => a.AttributeId);

        }
    }
}
