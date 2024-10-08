using ECommerce.Domain.AggregateModels.ShopAggregate;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Infrastructure.Repositories.ShopAggregate
{
    public class ShopRepository : Repository<Shop, ECommerceDbContext>, IShopRepository
    {
        public ShopRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
