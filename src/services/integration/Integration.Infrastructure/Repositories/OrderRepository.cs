using ECommerce.Shared.SeedWork;
using Integration.Domain.OrderAggregateModels;

namespace Integration.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, ECommerceDbContext>, IOrderRepository
    {
        public OrderRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
