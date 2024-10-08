using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.CustomerAggregate
{
    public class CustomerAddressEntityConfiguration : EntityConfiguration<CustomerAddress>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.Property(a => a.CustomerId).IsRequired();
            builder.Property(a => a.ReceiverName).IsRequired();
            builder.Property(a => a.ReceiverPhoneNumber).IsRequired();

            builder.HasOne(a => a.Customer)
                .WithMany(a => a.CustomerAddresses)
                .HasForeignKey(a => a.CustomerId);

            builder.HasOne(a => a.Ward)
                .WithMany()
                .HasForeignKey(a => a.WardId)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
