using ECommerce.Shared.SeedWork;
using Integration.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integration.Infrastructure.EntityConfigurations
{
    public class AttributeMappingEntityConfiguration : EntityConfiguration<AttributeMapping>
    {
        public override void ConfigureEntity(EntityTypeBuilder<AttributeMapping> builder)
        {
            builder.HasKey(a => a.AttributeValueId);
        }
    }
}
