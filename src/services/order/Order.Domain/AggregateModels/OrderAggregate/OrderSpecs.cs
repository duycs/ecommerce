using ECommerce.Shared.Dotnet.Specifications;
using System;

namespace Order.Domain.AggregateModels.OrderAggregate
{
    public static class OrderSpecs
    {
        public static ISpecification<CustomerOrder> GetByIdAndCustomerId(Guid id, Guid customerId)
            => new Specification<CustomerOrder>(a=>a.Id == id && a.CustomerId == customerId);
    }
}
