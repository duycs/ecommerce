using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            InverseParent = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? ParentId { get; set; }
        public string Code { get; set; }
        public string SiteTitle { get; set; }
        public string Slug { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Priority { get; set; }

        public virtual ProductCategory Parent { get; set; }
        public virtual ICollection<ProductCategory> InverseParent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
