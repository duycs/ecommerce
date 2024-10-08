using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Synchronize.Domain.EComAggregate
{
    [Table("product_children", Schema = "public")]
    public class ProductChild : PriorityEntity
    {
        public Guid ProductId { get; private set; }
        public uint QuantityInStock { get; private set; }
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public Guid[] AttributeValueIds { get; private set; }

        public virtual Product Product { get; private set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; private set; }

        protected ProductChild() { }

        public ProductChild(string sku, string name)
        {
            Id = Guid.NewGuid();
            Sku = sku;
            Name = name;
        }

        public bool UpdateQuantityInStock(uint quantityInStock)
        {
            if (quantityInStock != QuantityInStock)
            {
                QuantityInStock = quantityInStock;
                return true;
            }
            return false;
        }

        public void AddPrice(ProductPrice price)
        {
            ProductPrices ??= new List<ProductPrice>();
            ProductPrices.Add(price);
        }

        public void SetAttributeValues(Guid[] ids)
        {
            AttributeValueIds = ids;
        }
    }
}