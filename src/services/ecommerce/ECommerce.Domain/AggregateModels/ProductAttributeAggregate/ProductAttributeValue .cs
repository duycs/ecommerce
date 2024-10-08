using ECommerce.Shared.SeedWork;
using System;

namespace ECommerce.Domain.AggregateModels.ProductAttributeAggregate
{
    public class ProductAttributeValue : PriorityEntity
    {
        public Guid AttributeId { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }

        public virtual ProductAttribute ProductAttribute { get; private set; }

        public ProductAttributeValue()
        {

        }
    }
}
