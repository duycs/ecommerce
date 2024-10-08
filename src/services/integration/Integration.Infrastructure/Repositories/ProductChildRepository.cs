using ECommerce.Shared.SeedWork;
using Integration.Domain.ECommerceAggregateModels;

namespace Integration.Infrastructure.Repositories
{
    public class ProductChildRepository : Repository<ProductChild, ECommerceDbContext>, IProductChildRepository
    {
        public ProductChildRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
