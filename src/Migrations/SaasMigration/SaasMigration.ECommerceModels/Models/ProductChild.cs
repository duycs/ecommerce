using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class ProductChild
    {
        public ProductChild()
        {
            CartDetails = new HashSet<CartDetail>();
            ProductPrices = new HashSet<ProductPrice>();
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public long QuantityInStock { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Priority { get; set; }
        public Guid[] AttributeValueIds { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
