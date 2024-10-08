using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class ProductAttribute
    {
        public ProductAttribute()
        {
            ProductAttributeValues = new HashSet<ProductAttributeValue>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Priority { get; set; }
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}
