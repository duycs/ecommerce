using ECommerce.Shared.SeedWork;
using Notification.Domain.AggregateModels.TemplateAggregate;
using System.Threading.Tasks;

namespace Notification.Infrastructure.Repositories
{
    public class NotificationTemplateRepository : Repository<NotificationTemplate, NotificationDbContext>, INotificationTemplateRepository
    {
        public NotificationTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<NotificationTemplate> GetByKeyAsync(string key)
        {
            return await _dbSet.FindAsync(key);
        }
    }
}
