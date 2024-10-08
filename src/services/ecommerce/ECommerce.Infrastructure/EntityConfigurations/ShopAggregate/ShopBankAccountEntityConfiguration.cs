using ECommerce.Domain.AggregateModels.ShopAggregate;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.EntityConfigurations.ShopAggregate
{
    public class ShopBankAccountEntityConfiguration : EntityConfiguration<ShopBankAccount>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ShopBankAccount> builder)
        {
            builder.HasIndex(a => a.NumberAccount).IsUnique();
            builder.HasOne(a => a.Shop)
                .WithMany(a => a.ShopBankAccounts)
                .HasForeignKey(a => a.ShopId);
        }
    }
}
