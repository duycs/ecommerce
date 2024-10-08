using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Infrastructure.Repositories.CartAggregate
{
    public class CartRepository : Repository<Cart, ECommerceDbContext>, ICartRepository
    {
        public CartRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
