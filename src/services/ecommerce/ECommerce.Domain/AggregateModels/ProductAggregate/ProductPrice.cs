using ECommerce.Shared.SeedWork;
using System;

namespace ECommerce.Domain.AggregateModels.ProductAggregate
{
    public class ProductPrice : DateModiferTrackingEntity
    {
        public Guid ProductId { get; private set; }
        public Guid ProductChildId { get; private set; }
        public int QuantityFrom { get; private set; }
        public int QuantityTo { get; private set; }
        public decimal Price { get; private set; }
        public decimal? PriceDiscount { get; private set; }
        public bool IsLimitQuantity { get; private set; }

        public virtual Product ParentProduct { get; private set; } 
        public virtual ProductChild ProductChild { get; private set; }

    }
}
