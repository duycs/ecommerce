using ECommerce.Shared.SeedWork;
using System;

namespace ECommerce.Domain.AggregateModels.ProductAggregate
{
    public class NewProduct : PriorityEntity
    {
        public Guid ProductId { get; private set; }

        public virtual Product Product { get; private set; }
    }
}
