using ECommerce.Domain.AggregateModels.LocationAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.LocationAggregate
{
    public class WardEntityConfiguration : EntityConfiguration<Ward>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Ward> builder)
        {
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.DistrictId).IsRequired();

            builder.HasOne(a => a.District)
                .WithMany(a => a.Wards)
                .HasForeignKey(a => a.DistrictId);
        }
    }
}
