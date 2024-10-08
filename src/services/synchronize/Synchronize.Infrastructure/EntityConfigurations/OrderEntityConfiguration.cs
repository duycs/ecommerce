using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Synchronize.Domain.OrderAggregate;

namespace Synchronize.Infrastructure.EntityConfigurations
{
    public class OrderEntityConfiguration : EntityConfiguration<Order>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Order> builder)
        {
            builder.Ignore(a => a.OrderStatus);
        }
    }
}
