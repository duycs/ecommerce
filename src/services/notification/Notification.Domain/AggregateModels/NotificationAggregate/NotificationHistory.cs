using ECommerce.Shared.SeedWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Notification.Domain.AggregateModels.TemplateAggregate;
using Notification.Domain.DomainEvents;
using Notification.Domain.Enum;
using Notification.Domain.Templates;
using System;
using System.Collections.Generic;

namespace Notification.Domain.AggregateModels.NotificationAggregate
{
    public class NotificationHistory : DateTrackingEntity, IAggregateRoot
    {
        public Guid UserId { get; private set; }
        public string NotificationTemplateId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public int Status { get; private set; }

        public string Payload { get; private set; }

        public virtual object PayloadObject
        {
            get => string.IsNullOrEmpty(Payload) ? null : JsonConvert.DeserializeObject<object>(Payload);
            private set => Payload = JsonConvert.SerializeObject(value, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });
        }

        public NotificationStatus NotificationStatus
        {
            get => Enumeration.FromValue<NotificationStatus>(Status);
            private set { Status = value.Id; }
        }

        public virtual NotificationTemplate NotificationTemplate { get; private set; }

        protected NotificationHistory()
        {
        }

        public NotificationHistory(Guid userId, NotificationTemplate notificationTemplate, object payload)
        {
            UserId = userId;
            NotificationTemplate = notificationTemplate;
            Title = NotificationTemplate.Title;
            PayloadObject = payload;
            Content = Renderer.Render(NotificationTemplate.Content, new Dictionary<string, string> { }, payload);
            NotificationStatus = NotificationStatus.UnSeen;
            AddDomainEvent(new NotificationCreatedDomainEvent(this));
        }

        public void Seen()
        {
            NotificationStatus = NotificationStatus.Seen;
        }
    }
}
