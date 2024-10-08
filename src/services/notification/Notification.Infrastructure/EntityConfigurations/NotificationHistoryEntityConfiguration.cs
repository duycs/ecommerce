using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Notification.Domain.AggregateModels.NotificationAggregate;

namespace Notification.Infrastructure.EntityConfigurations
{
    public class NotificationHistoryEntityConfiguration : EntityConfiguration<NotificationHistory>
    {
        public override void ConfigureEntity(EntityTypeBuilder<NotificationHistory> builder)
        {
            var serializer = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy(),
                },
            };

            builder.Ignore(a => a.NotificationStatus).Ignore(a => a.PayloadObject);
            builder.HasOne(a => a.NotificationTemplate)
                .WithMany()
                .HasForeignKey(a => a.NotificationTemplateId);
            builder.Property(a => a.Payload)
               .HasColumnType("jsonb");
        }
    }
}
