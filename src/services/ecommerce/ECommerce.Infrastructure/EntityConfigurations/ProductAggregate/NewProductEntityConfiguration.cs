using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.ProductAggregate
{
    public class NewProductEntityConfiguration : EntityConfiguration<NewProduct>
    {
        public override void ConfigureEntity(EntityTypeBuilder<NewProduct> builder)
        {
            builder.HasIndex(a => a.ProductId).IsUnique();

            builder.Property(a => a.ProductId).IsRequired();

            builder.Property(a => a.Priority).IsRequired();

            builder.HasOne(a => a.Product)
                .WithOne(a => a.NewProduct)
                .HasForeignKey<NewProduct>(a => a.ProductId);
        }
    }
}
