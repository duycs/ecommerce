using ECommerce.Shared.SeedWork;
using Integration.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integration.Infrastructure.EntityConfigurations
{
    public class CategoryMappingEntityConfiguration : EntityConfiguration<CategoryMapping>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CategoryMapping> builder)
        {
            builder.HasKey(a => a.OldId);
        }
    }
}
