using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Domain.AggregateModels.TemplateAggregate;

namespace Notification.Infrastructure.EntityConfigurations
{
    public class NotificationTemplateEntityConfiguration : EntityConfiguration<NotificationTemplate>
    {
        public override void ConfigureEntity(EntityTypeBuilder<NotificationTemplate> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
