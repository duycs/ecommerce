using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.CustomerAggregate
{
    public class CustomerEntityConfiguration : EntityConfiguration<Customer>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(a => a.PhoneNumber).IsUnique();

            builder.Property(a => a.PhoneNumber).IsRequired();

            builder.Property(a => a.Name).IsRequired();

            builder.Property(a => a.Liabilities)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(a => a.MaxLiabilities)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
