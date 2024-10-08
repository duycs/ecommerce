using System;
using System.Collections.Generic;

namespace ECommerce.Application.Models.Products
{
    public abstract class BaseProductChildDto 
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public uint QuantityInStock { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public IEnumerable<Guid> AttributeValueIds { get; set; }
        public int Priority { get; }
    }
}
