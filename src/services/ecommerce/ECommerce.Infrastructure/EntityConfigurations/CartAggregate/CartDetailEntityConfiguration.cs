using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.CartAggregate
{
    public class CartDetailEntityConfiguration : EntityConfiguration<CartDetail>
    {
        public override void ConfigureEntity(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasIndex(a => new { a.CartId, a.ProductChildId }).IsUnique();

            builder.Property(a => a.Quantity).IsRequired();

            builder.HasOne(a => a.ProductChild)
                .WithMany(a => a.CartDetails)
                .HasForeignKey(a => a.ProductChildId);
        }
    }
}
