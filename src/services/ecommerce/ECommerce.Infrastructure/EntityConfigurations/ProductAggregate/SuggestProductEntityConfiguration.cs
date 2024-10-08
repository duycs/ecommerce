using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.ProductAggregate
{
    public class SuggestProductEntityConfiguration : EntityConfiguration<SuggestProduct>
    {
        public override void ConfigureEntity(EntityTypeBuilder<SuggestProduct> builder)
        {
            builder.HasIndex(e => e.ProductId).IsUnique();

            builder.Property(a => a.ProductId).IsRequired();

            builder.Property(a => a.Priority).IsRequired();

            builder.HasOne(a => a.Product)
                .WithOne(a => a.SuggestProduct)
                .HasForeignKey<SuggestProduct>(a => a.ProductId);
        }
    }
}
