using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Application.Models.Products
{
    public class ProductDetailsDto : BaseProductDto
    {
        public IEnumerable<ProductDetailsChildDto> Items { get; set; }
        public IEnumerable<ProductDetailsAttributeDto> Attributes { get; set; }

        public void ConfigAttributeQuantity()
        {
            foreach (var attribute in Attributes)
            {
                foreach (var value in attribute.Values)
                {
                    if (value != null)
                    {
                        value.Quantity = Convert.ToUInt32(Items?.Where(i => i.AttributeValueIds.Contains(value.Id)).Sum(i => i.Quantity) ?? 0);
                    }
                }
            }
        }
    }

    public class ProductDetailsChildDto
    {
        public Guid Id { get; set; }
        public uint Quantity { get; set; }
        public uint QuantityInCart { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public IEnumerable<Guid> AttributeValueIds { get; set; }
    }

    public class ProductDetailsAttributeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public IList<ProductDetailsAttributeValueDto> Values { get; set; }
    }

    public class ProductDetailsAttributeValueDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public uint Quantity { get; set; }
        public uint QuantityInCart { get; set; }
    }
}
