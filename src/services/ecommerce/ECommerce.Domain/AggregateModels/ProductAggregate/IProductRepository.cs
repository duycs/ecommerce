using ECommerce.Shared.Dotnet.Specifications;
using ECommerce.Shared.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<ProductChild>> GetChidren(ISpecification<ProductChild> spec);
        void UpdateChild(ProductChild child);
    }
}
