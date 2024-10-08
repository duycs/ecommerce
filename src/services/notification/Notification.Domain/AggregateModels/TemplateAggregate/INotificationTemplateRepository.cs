using ECommerce.Shared.SeedWork;
using System.Threading.Tasks;

namespace Notification.Domain.AggregateModels.TemplateAggregate
{
    public interface INotificationTemplateRepository : IRepository<NotificationTemplate>
    {
        Task<NotificationTemplate> GetByKeyAsync(string key);
    }
}
