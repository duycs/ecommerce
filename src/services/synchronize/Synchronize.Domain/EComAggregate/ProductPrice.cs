using ECommerce.Shared.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Synchronize.Domain.EComAggregate
{
    [Table("product_prices", Schema = "public")]
    public class ProductPrice : DateModiferTrackingEntity
    {
        public Guid ProductChildId { get; private set; }
        public Guid ProductId { get; private set; }
        public int QuantityFrom { get; private set; }
        public int QuantityTo { get; private set; }
        public decimal Price { get; private set; }
        public bool IsLimitQuantity { get; private set; }

        protected ProductPrice() { }

        public ProductPrice(Guid productChildId, Guid productId, decimal price)
        {
            Id = Guid.NewGuid();
            ProductChildId = productChildId;
            ProductId = productId;
            Price = price;
        }

        public bool UpdatePrice(decimal price)
        {
            if (price != Price)
            {
                Price = price;
                return true;
            }
            return false;
        }
    }
}
