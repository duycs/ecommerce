using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.AggregateModels.ProductAttributeAggregate
{
    public class ProductAttribute : PriorityEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Guid ProductId { get; private set; }
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; private set; }
        public virtual Product Product { get; private set; }
        public ProductAttribute()
        { }
    }
}
