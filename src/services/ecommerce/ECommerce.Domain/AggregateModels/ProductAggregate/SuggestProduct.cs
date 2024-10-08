using ECommerce.Shared.SeedWork;
using System;

namespace ECommerce.Domain.AggregateModels.ProductAggregate
{
    public class SuggestProduct : PriorityEntity
    {
        public Guid ProductId { get; private set; }

        public virtual Product Product { get; private set; }
    }
}
