using ECommerce.Domain.AggregateModels.ProductCategoryAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Infrastructure.EntityConfigurations.ProductCategoryAggregate
{
    public class ProductCategoryEntityConfiguration : EntityConfiguration<ProductCategory>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasIndex(a => a.Code).IsUnique();

            builder.HasIndex(a => a.Name).IsUnique();

            builder.Property(a => a.Code).IsRequired();

            builder.Property(a => a.Name).IsRequired();

            builder.Property(a => a.SiteTitle).HasMaxLength(256);

            builder.Property(a => a.Slug).HasMaxLength(256);

            builder.Property(a => a.MetaKeywords).HasMaxLength(160);

            builder.Property(a => a.MetaDescription).HasMaxLength(160);

            builder.Property(a => a.Description).HasMaxLength(600);

            builder.Property(a=>a.Priority).HasDefaultValue(0);

            builder.HasOne(a => a.Parent)
                .WithMany(a => a.Children)
                .HasForeignKey(a => a.ParentId);

            builder.HasMany(a => a.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);
        }
    }
}
