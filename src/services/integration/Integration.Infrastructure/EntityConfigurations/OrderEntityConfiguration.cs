using ECommerce.Shared.SeedWork;
using Integration.Domain.OrderAggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integration.Infrastructure.EntityConfigurations
{
    public class OrderEntityConfiguration : EntityConfiguration<Order>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders", "order", t => t.ExcludeFromMigrations());
            builder.HasKey(a => a.Id);
            builder.HasMany(o => o.Details)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
