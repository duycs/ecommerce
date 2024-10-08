using ECommerce.Shared.SeedWork;
using Integration.Domain.AggregateModels.SystemLogAggregate;

namespace Integration.Infrastructure.Repositories.SystemLogAggregate
{
    public class SystemLogRepository : Repository<SystemLog, ECommerceDbContext>, ISystemLogRepository
    {
        public SystemLogRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
