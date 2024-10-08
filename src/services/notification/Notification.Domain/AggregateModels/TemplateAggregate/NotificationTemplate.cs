using ECommerce.Shared.SeedWork;

namespace Notification.Domain.AggregateModels.TemplateAggregate
{
    public class NotificationTemplate : IAggregateRoot
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }

        public NotificationTemplate(string id)
        {
            Id = id;
        }

        public void Update(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
