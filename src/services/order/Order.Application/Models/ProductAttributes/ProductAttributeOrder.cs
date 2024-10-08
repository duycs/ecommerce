using System;
using Order.Domain.AggregateModels.OrderAggregate;

namespace Order.Application.Models.ProductAttributes
{
    public class ProductAttributeOrder //: ProductAttributeValue
    {
        public int TotalQuantity { get; set; }
        public string Code { get; set; }
    }
}
