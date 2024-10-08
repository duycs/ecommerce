using ECommerce.Domain.AggregateModels.BrandAggregate;
using ECommerce.Domain.AggregateModels.ProductCategoryAggregate;
using ECommerce.Domain.AggregateModels.ShopAggregate;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Domain.AggregateModels.ProductAttributeAggregate;
using ECommerce.Shared.SeedWork;

namespace ECommerce.Domain.AggregateModels.ProductAggregate
{
    public class Product : DateModiferTrackingEntity, IAggregateRoot
    {
        public Guid ShopId { get; private set; }
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public Guid? BrandId { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid? UnitId { get; private set; }
        public string Description { get; private set; }
        public string Content { get; private set; }
        public string Image { get; private set; }
        public string ThumbImage { get; private set; }
        public string[] Images { get; private set; }
        public string MetaKeywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string SiteTitle { get; private set; }
        public bool IsSellFullSize { get; private set; }
        public NpgsqlTsVector SearchVector { get; set; }
        public virtual Shop Shop { get; private set; }
        public virtual ProductCategory Category { get; private set; }
        public virtual Brand Brand { get; private set; }
        public virtual IList<ProductChild> Children { get; private set; }
        public virtual BestSellingProduct BestSellingProduct { get; private set; }
        public virtual IEnumerable<ProductPrice> ProductPrices { get; private set; }
        public virtual NewProduct NewProduct { get; private set; }
        public virtual SuggestProduct SuggestProduct { get; private set; }
        public virtual ICollection<ProductAttribute> Attributes { get; private set; }
        protected Product()
        {

        }

        public void OrderChild(Guid childId, uint quantity)
        {
            var child = Children.SingleOrDefault(a => a.Id == childId);
            child?.Order(quantity);
        }

        public ProductChild GetChild(Guid childId)
        {
            return Children.SingleOrDefault(a => a.Id == childId);
        }

    }
}
