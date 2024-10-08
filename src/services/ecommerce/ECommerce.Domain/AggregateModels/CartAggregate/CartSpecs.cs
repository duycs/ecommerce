using ECommerce.Shared.Dotnet.Specifications;
using System;

namespace ECommerce.Domain.AggregateModels.CartAggregate
{
    public static class CartSpecs
    {
        public static ISpecification<Cart> GetByCustomerId(Guid customerId)
            => new Specification<Cart>(a => a.CustomerId == customerId);
    }
}
