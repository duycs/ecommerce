using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Infrastructure.Repositories.CustomerAggregate
{
    public class CustomerRepository : Repository<Customer, ECommerceDbContext>, ICustomerRepository
    {
        public CustomerRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
