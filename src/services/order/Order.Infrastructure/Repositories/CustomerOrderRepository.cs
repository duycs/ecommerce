using ECommerce.Shared.SeedWork;
using Order.Domain.AggregateModels.OrderAggregate;

namespace Order.Infrastructure.Repositories
{
    public class CustomerOrderRepository : Repository<CustomerOrder, OrderDbContext>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
