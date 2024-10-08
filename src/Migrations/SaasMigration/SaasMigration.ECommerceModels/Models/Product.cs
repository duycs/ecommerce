using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductAttributes = new HashSet<ProductAttribute>();
            ProductChildren = new HashSet<ProductChild>();
            ProductPrices = new HashSet<ProductPrice>();
        }

        public Guid Id { get; set; }
        public Guid ShopId { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public Guid? BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string ThumbImage { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string SiteTitle { get; set; }
        public bool IsSellFullSize { get; set; }
        public Guid? UnitId { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public NpgsqlTsVector SearchVector { get; set; }
        public string[] Images { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ProductCategory Category { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual BestSellingProduct BestSellingProduct { get; set; }
        public virtual NewProduct NewProduct { get; set; }
        public virtual SuggestProduct SuggestProduct { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ICollection<ProductChild> ProductChildren { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
