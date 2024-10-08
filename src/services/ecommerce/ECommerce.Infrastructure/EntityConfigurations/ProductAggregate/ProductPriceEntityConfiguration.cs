using ECommerce.Domain.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Infrastructure.EntityConfigurations.ProductAggregate
{
    public class ProductPriceEntityConfiguration : EntityConfiguration<ProductPrice>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.Property(a => a.ProductChildId)
               .IsRequired();

            builder.Property(a => a.Price)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(a => a.ProductId)
                    .IsRequired();

            builder.Property(a => a.QuantityFrom)
                 .IsRequired();

            builder.HasOne(a => a.ProductChild)
                .WithMany(a => a.ProductPrices)
                .HasForeignKey(a => a.ProductChildId);

        }
    }
}
