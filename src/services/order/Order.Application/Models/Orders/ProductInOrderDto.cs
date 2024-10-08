using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Order.Application.Models.ProductAttributes;

namespace Order.Application.Models.Orders
{

    /// <summary>
    /// Mặc định Name1 là màu sắc, Name2 là size,
    /// prioriy color = 1, priority size = 2
    /// </summary>
    public class ProductInOrderDto
    {
        public Guid Id { get; set; }
        public string ProductSku { get; set; }
        public string Name { get; set; }
        public string ProductImage { get; set; }
        public int TotalQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalMoney => TotalQuantity * Price;
        [JsonIgnore]
        public string Name1 { get; set; }
        [JsonIgnore]
        public int Priority1 { get; set; }
        [JsonIgnore]
        public string Name2 { get; set; }
        [JsonIgnore]
        public int Priority2 { get; set; }
        public string AttributeColorName { get; set; }
        public IEnumerable<ProductAttributeOrder> AttributeValuesList { get; set; }
        public ProductInOrderDto() { }
        public void SetDefaultColor()
        {
            if (Priority1 == 2)
            {
                var priority = Priority1;
                Priority1 = Priority2;
                Priority2 = priority;

                var name = Name1;
                Name1 = Name2;
                Name2 = name;
            }
        }
    }

}
