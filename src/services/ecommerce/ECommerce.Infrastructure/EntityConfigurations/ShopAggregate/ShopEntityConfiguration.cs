using ECommerce.Domain.AggregateModels.ShopAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.ShopAggregate
{
    public class ShopEntityConfiguration : EntityConfiguration<Shop>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Shop> builder)
        {
            builder.HasIndex(a => a.Code).IsUnique();

            builder.HasIndex(a => a.PhoneNumber).IsUnique();

            builder.HasIndex(a => a.Name).IsUnique();

            builder.Property(a => a.Code).IsRequired();

            builder.Property(a => a.PhoneNumber).IsRequired();

            builder.Property(a => a.Name).IsRequired();

            builder.Property(a => a.Address).IsRequired();

            builder.HasOne(a => a.Ward)
                .WithMany()
                .HasForeignKey(a => a.WardId);
        }
    }
}
