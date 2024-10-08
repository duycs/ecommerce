using ECommerce.Shared.SeedWork;
using Integration.Domain.ECommerceAggregateModels;

namespace Integration.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, ECommerceDbContext>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
