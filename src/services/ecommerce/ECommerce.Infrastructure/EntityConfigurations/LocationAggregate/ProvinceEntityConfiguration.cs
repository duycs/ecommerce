using ECommerce.Domain.AggregateModels.LocationAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.LocationAggregate
{
    internal class ProvinceEntityConfiguration : EntityConfiguration<Province>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Province> builder)
        {
            builder.Property(a => a.Name).IsRequired();
        }
    }
}
