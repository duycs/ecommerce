using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.ProductAggregate
{
    public class BestSellingProductEnityConfiguration : EntityConfiguration<BestSellingProduct>
    {
        public override void ConfigureEntity(EntityTypeBuilder<BestSellingProduct> builder)
        {
            builder.HasIndex(a => a.ProductId).IsUnique();

            builder.Property(a => a.ProductId).IsRequired();

            builder.Property(a=>a.Priority).IsRequired();

            builder.HasOne(a => a.Product)
                .WithOne(a => a.BestSellingProduct)
                .HasForeignKey<BestSellingProduct>(a => a.ProductId);
        }
    }
}
