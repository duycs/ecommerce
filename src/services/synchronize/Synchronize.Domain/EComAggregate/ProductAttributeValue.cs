using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Synchronize.Domain.EComAggregate
{
    [Table("product_attribute_values", Schema = "public")]
    public class ProductAttributeValue : PriorityEntity
    {
        public Guid AttributeId { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }

        public virtual ProductAttribute ProductAttribute { get; private set; }

        protected ProductAttributeValue()
        {
        }

        public ProductAttributeValue(string code, string name, string value)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
            Value = value;
        }
    }
}
