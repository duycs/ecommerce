using ECommerce.Application.Models.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Application.Models.Carts
{
    public class ProductsCartDto : BaseProductDto
    {
        public IList<AttributeValueDto> AttributeValueDtos { get; set; }
        //public decimal TotalPrice => AttributeValueDtos.Sum(a => a.Price);
    }


    public class AttributeValueDto
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public string AttributeValueName { get; set; }
        public string Sku { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public bool ProductIsSellFullSize { get; set; }
        public string BrandName { get; set; }
        public IEnumerable<AttributeValueChildDto> Children { get; set; }
        public decimal TotalAmount => Children.Sum(a => a.Price * a.QuantityOrder);
    }

    public class AttributeValueChildDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        [JsonIgnore]
        public string ProductImage { get; set; }
        [JsonIgnore]
        public bool ProductIsSellFullSize { get; set; }
        public string BrandName { get; set; }
        public uint QuantityOrder { get; set; }
        public uint QuantityInStock { get; set; }
        public Guid AttributeValueId { get; set; }
        public string AttributeValueName { get; set; }
        public string AttributeValue { get; set; }
        public string AttributeName { get; set; }
        public uint Priority { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public Guid[] AttributeValueIds { get; set; }
    }

    public class ProductChilCartdDto : BaseProductChildDto
    {
        public Guid CartDetailId { get; set; }
        public uint QuantityOrder { get; set; }
    }

}
