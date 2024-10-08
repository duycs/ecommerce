using ECommerce.Shared.SeedWork;
using Integration.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integration.Infrastructure.EntityConfigurations
{
    public class CustomerMappingEntityConfiguration : EntityConfiguration<CustomerMapping>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CustomerMapping> builder)
        {
            builder.HasKey(x => x.CustomerId);
            builder.HasIndex(x => x.OldId).IsUnique();
        }
    }
}
