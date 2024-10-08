using ECommerce.Shared.SeedWork;
using Integration.Domain.ECommerceAggregateModels;

namespace Integration.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer, ECommerceDbContext>, ICustomerRepository
    {
        public CustomerRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
