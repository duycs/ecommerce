using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.Dotnet.Specifications;
using ECommerce.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.ProductAggregate
{
    public class ProductRepository : Repository<Product, ECommerceDbContext>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<ProductChild>> GetChidren(ISpecification<ProductChild> spec)
        {
            return _dbContext.Set<ProductChild>().Where(spec.Predicate).ToListAsync();
        }

        public void UpdateChild(ProductChild child)
        {
            _dbContext.Set<ProductChild>().Update(child);
        }
    }
}
