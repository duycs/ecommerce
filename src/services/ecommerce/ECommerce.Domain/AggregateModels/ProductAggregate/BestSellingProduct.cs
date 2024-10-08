using System;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Domain.AggregateModels.ProductAggregate
{
    public class BestSellingProduct : PriorityEntity
    {
        public Guid ProductId { get; private set; }

        public virtual Product Product { get; private set; }
    }
}
