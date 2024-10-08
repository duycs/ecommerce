using ECommerce.Shared.SeedWork;
using Integration.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integration.Infrastructure.EntityConfigurations
{
    public class ChildProductMappingEntityConfiguration : EntityConfiguration<ChildProductMapping>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ChildProductMapping> builder)
        {
            builder.HasKey(a => a.ChildProductId);
            builder.HasIndex(a => a.OldId).IsUnique();
        }
    }
}
