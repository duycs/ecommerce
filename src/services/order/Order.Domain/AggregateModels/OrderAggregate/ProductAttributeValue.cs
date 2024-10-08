using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.AggregateModels.OrderAggregate
{
    public class ProductAttributeValue
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string AttributeName { get; set; }
        public int Priority { get; set; }

        public ProductAttributeValue()
        {
        }

        public ProductAttributeValue(Guid id, string code, string name, string value, string attributeName, int priority)
        {
            Id = id;
            Code = code;
            Name = name;
            Value = value;
            AttributeName = attributeName;
            Priority = priority;
        }
    }
}
