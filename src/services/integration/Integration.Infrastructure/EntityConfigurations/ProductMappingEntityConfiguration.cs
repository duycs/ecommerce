using ECommerce.Shared.SeedWork;
using Integration.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integration.Infrastructure.EntityConfigurations
{
    public class ProductMappingEntityConfiguration : EntityConfiguration<ProductMapping>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductMapping> builder)
        {
            builder.HasKey(a => a.ProductId);
            builder.HasIndex(a => a.OldId).IsUnique();
        }
    }
}
