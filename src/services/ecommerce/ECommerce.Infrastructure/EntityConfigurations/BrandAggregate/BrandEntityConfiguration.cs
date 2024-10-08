using ECommerce.Domain.AggregateModels.BrandAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.BrandAggregate
{
    public class BrandEntityConfiguration : EntityConfiguration<Brand>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Brand> builder)
        {
            builder.HasIndex(a => a.Code).IsUnique();

            builder.HasIndex(a => a.Name).IsUnique();

            builder.Property(c => c.Code).IsRequired();

            builder.Property(c => c.Name).IsRequired();

            builder.HasMany(a => a.Products)
                .WithOne(a => a.Brand)
                .HasForeignKey(a => a.BrandId);

            builder.Property(c => c.MetaKeywords).HasMaxLength(160);

            builder.Property(c => c.MetaDescription).HasMaxLength(160);

            builder.Property(c => c.Priority).HasDefaultValue(0);

        }
    }
}
