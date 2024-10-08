using ECommerce.Shared.SeedWork;
using Identity.Domain.AccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.EntityConfigurations
{
    public class AccountRoleEntityConfiguration : EntityConfiguration<AccountRole>
    {
        public override void ConfigureEntity(EntityTypeBuilder<AccountRole> builder)
        {
            builder.HasOne(t => t.Role)
                .WithMany()
                .HasForeignKey(t => t.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
