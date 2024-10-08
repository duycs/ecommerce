using ECommerce.Shared.SeedWork;
using Integration.Domain.AggregateModels;

namespace Integration.Infrastructure.Repositories
{
    public class CustomerMappingRepository : Repository<CustomerMapping, ECommerceDbContext>, ICustomerMappingRepository
    {
        public CustomerMappingRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
