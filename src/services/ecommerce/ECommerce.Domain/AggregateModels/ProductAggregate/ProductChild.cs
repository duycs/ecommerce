using ECommerce.Domain.AggregateModels.CartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Shared.SeedWork;
using ECommerce.Shared.Exceptions;
using ECommerce.Domain.AggregateModels.ProductAttributeAggregate;
using ECommerce.Shared.Extensions;

namespace ECommerce.Domain.AggregateModels.ProductAggregate
{
    public class ProductChild : PriorityEntity
    {
        public Guid ProductId { get; private set; }
        public uint QuantityInStock { get; private set; }
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public Guid[] AttributeValueIds { get; private set; }
        public virtual Product Product { get; private set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; private set; }
        public virtual ICollection<CartDetail> CartDetails { get; private set; }
        public virtual IEnumerable<ProductAttributeValue> AttributeValues
            => Product.Attributes.SelectMany(a => a.ProductAttributeValues).Where(a => AttributeValueIds.Contains(a.Id));

        protected ProductChild()
        {

        }
        public void Order(uint quantity)
        {
            QuantityInStock -= quantity;
        }

        public decimal GetPrice(uint quantity)
        {
            return ProductPrices
                .FirstOrDefault(a => a.QuantityFrom <= quantity && a.QuantityTo >= quantity || !a.IsLimitQuantity)?.Price
                   ?? 0;
        }

        public void AddOrUpdateCartDetail(Guid cartId, uint quantity)
        {
            var detail = CartDetails.FirstOrDefault(a => a.CartId == cartId);
            if (detail == null)
            {
                if (quantity > QuantityInStock)
                {
                    throw new BusinessRuleException(ECommerceBusinessRule.QuantityNotEnough);
                }
                CartDetails.Add(new CartDetail(cartId, Id, quantity));
            }
            else
            {

                detail.UpdateAddQuantity(quantity);
            }
        }

        public void AddQuantity(uint quantity)
        {
            QuantityInStock += quantity;
        }
    }
}
