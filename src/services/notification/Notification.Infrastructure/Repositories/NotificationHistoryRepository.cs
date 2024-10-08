using ECommerce.Shared.SeedWork;
using Notification.Domain.AggregateModels.NotificationAggregate;

namespace Notification.Infrastructure.Repositories
{
    public class NotificationHistoryRepository : Repository<NotificationHistory, NotificationDbContext>, INotificationHistoryRepository
    {
        public NotificationHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
