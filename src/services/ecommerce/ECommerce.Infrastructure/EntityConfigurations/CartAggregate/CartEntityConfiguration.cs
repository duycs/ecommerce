using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.CartAggregate
{
    public class CartEntityConfiguration : EntityConfiguration<Cart>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(a => a.CustomerId).IsRequired();

            builder.HasOne(a => a.Customer)
                .WithOne(a => a.Cart)
                .HasForeignKey<Cart>(a => a.CustomerId);

            builder.HasMany(a => a.CartDetails)
                .WithOne(a => a.Cart)
                .HasForeignKey(a => a.CartId);

        }
    }
}
