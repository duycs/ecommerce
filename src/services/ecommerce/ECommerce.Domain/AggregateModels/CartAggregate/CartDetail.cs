using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.SeedWork;
using System;

namespace ECommerce.Domain.AggregateModels.CartAggregate
{
    public class CartDetail : DateModiferTrackingEntity
    {
        public Guid CartId { get; private set; }
        public Guid ProductChildId { get; private set; }
        public decimal Price { get; private set; }
        public uint Quantity { get; private set; }
        public virtual Cart Cart { get; private set; }
        public virtual ProductChild ProductChild { get; private set; }

        protected CartDetail() { }

        public void Order()
        {
            if (Quantity > ProductChild.QuantityInStock)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.QuantityNotEnough);
            }
            if (Price != ProductChild.GetPrice(Quantity))
            {
                throw new BusinessRuleException(ECommerceBusinessRule.PriceChanged);
            }
            ProductChild.Order(Quantity);
        }

        public CartDetail(Guid cartId, ProductChild child, uint quantity)
        {
            ProductChild = child;
            CartId = cartId;
            if (quantity > ProductChild.QuantityInStock)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.QuantityNotEnough);
            }
            Quantity = quantity;
            Price = child.GetPrice(Quantity);
        }

        public CartDetail(Guid cartId, Guid productChildId, uint quantity)
        {
            CartId = cartId;
            ProductChildId = productChildId;
            Quantity = quantity;

        }

        public void UpdateAddQuantity(uint quanity)
        {
            if (Quantity + quanity > ProductChild.QuantityInStock)
                throw new BusinessRuleException(ECommerceBusinessRule.QuantityNotEnough);
            Quantity += quanity;
        }

        public void UpdateQuantity(uint quantity)
        {
            if (quantity > ProductChild.QuantityInStock)
                throw new BusinessRuleException(ECommerceBusinessRule.QuantityNotEnough);
            Quantity = quantity;
        }
    }
}
