using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.SeedWork;
using System;
using System.ComponentModel.DataAnnotations;

namespace Integration.Domain.ECommerceAggregateModels
{
    public class ProductChild : ModifierTrackingEntity, IAggregateRoot
    {
        [ConcurrencyCheck]
        public uint QuantityInStock { get; private set; }
        public Guid ProductId { get; private set; }

        protected ProductChild() { }

        public void RemoveQuantity(uint quantity)
        {
            if (quantity > QuantityInStock)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.QuantityNotEnough);
            }
            QuantityInStock -= quantity;
        }

        public void AddQuantity(uint quantity)
        {
            QuantityInStock += quantity;
        }

        public void ChangeQuantity(uint quantity)
        {
            QuantityInStock = quantity;
        }
    }
}
