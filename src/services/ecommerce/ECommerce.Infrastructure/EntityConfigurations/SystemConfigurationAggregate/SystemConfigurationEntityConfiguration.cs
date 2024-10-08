using ECommerce.Domain.AggregateModels.SystemConfigurationAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Infrastructure.EntityConfigurations.SystemConfigurationAggregate
{
    public class SystemConfigurationEntityConfiguration : EntityConfiguration<SystemConfiguration>
    {
        public override void ConfigureEntity(EntityTypeBuilder<SystemConfiguration> builder)
        {
            builder.HasKey(a => a.Key);
            builder.Property(a => a.Priority).HasDefaultValue(0);
        }
    }
}
