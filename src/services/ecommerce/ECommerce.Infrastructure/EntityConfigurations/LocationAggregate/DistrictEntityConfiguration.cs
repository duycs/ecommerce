using ECommerce.Domain.AggregateModels.LocationAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.LocationAggregate
{
    public class DistrictEntityConfiguration : EntityConfiguration<District>
    {
        public override void ConfigureEntity(EntityTypeBuilder<District> builder)
        {
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.ProvinceId).IsRequired();

            builder.HasOne(a => a.Province)
                .WithMany(a => a.Districts)
                .HasForeignKey(a => a.ProvinceId);
        }
    }
}
