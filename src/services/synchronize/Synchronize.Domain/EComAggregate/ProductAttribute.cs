using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Synchronize.Domain.EComAggregate
{
    [Table("product_attributes", Schema = "public")]
    public class ProductAttribute : PriorityEntity
    {
        public string Name { get; private set; }
        public Guid ProductId { get; private set; }
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; private set; }
        public virtual Product Product { get; private set; }
        protected ProductAttribute()
        { }

        public ProductAttribute(string name, Guid productId, int priority)
        {
            Id = Guid.NewGuid();
            Name = name;
            ProductId = productId;
            Priority = priority;
        }

        public void AddValue(ProductAttributeValue value)
        {
            ProductAttributeValues ??= new List<ProductAttributeValue>();
            ProductAttributeValues.Add(value);
        }
    }
}
