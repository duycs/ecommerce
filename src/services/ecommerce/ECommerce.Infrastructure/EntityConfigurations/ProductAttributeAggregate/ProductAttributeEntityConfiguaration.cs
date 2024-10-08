using ECommerce.Domain.AggregateModels.ProductAttributeAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Infrastructure.EntityConfigurations.ProductAttributeAggregate
{
    public class ProductAttributeEntityConfiguaration : EntityConfiguration<ProductAttribute>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired();

            builder.Property(a=>a.Priority).HasDefaultValue(0);
        }
    }
}
