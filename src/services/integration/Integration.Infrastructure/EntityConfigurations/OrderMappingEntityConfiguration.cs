using ECommerce.Shared.SeedWork;
using Integration.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integration.Infrastructure.EntityConfigurations
{
    public class OrderMappingEntityConfiguration : EntityConfiguration<OrderMapping>
    {
        public override void ConfigureEntity(EntityTypeBuilder<OrderMapping> builder)
        {
            builder.HasKey(e => e.OrderId);
            builder.HasIndex(e => e.OldId).IsUnique();
        }
    }
}
