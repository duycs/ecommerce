using System;

namespace ECommerce.Application.Models.Products
{
    public abstract class BaseProductChildDto 
    {
        public Guid Id { get; }
        public Guid ParentId { get; }
        public Guid FixedAttributeValueId { get; }
        public Guid InputAttributeValueId { get; }
        public int QuantityInStock { get; }
        public Guid? ProductChildSAASId { get; }
        public string Sku { get; }
        public string Name { get; }
        public int Priority { get; }
    }
}
