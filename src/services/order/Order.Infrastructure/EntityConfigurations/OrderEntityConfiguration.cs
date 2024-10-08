using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.AggregateModels.OrderAggregate;

namespace Order.Infrastructure.EntityConfigurations
{
    public class OrderEntityConfiguration : EntityConfiguration<CustomerOrder>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CustomerOrder> builder)
        {
            builder.HasMany(o => o.Details)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);

            builder.Ignore(a => a.OrderStatus)
                .Ignore(a => a.OrderCode)
                .Ignore(a => a.TotalPrice)
                .Ignore(a => a.TotalNetPrice);

            builder.HasIndex(a => a.SaasCode).IsUnique();
        }
    }
}
