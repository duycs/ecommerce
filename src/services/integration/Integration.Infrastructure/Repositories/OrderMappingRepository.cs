using ECommerce.Shared.SeedWork;
using Integration.Domain.AggregateModels;

namespace Integration.Infrastructure.Repositories
{
    public class OrderMappingRepository : Repository<OrderMapping, ECommerceDbContext>, IOrderMappingRepository
    {
        public OrderMappingRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
