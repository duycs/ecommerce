using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Domain.OrderAggregateModels
{
    public class ProductAttributeValue
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string AttributeName { get; set; }
        public int Priority { get; set; }
    }
}
