using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;

namespace ECommerce.Domain.AggregateModels.ProductCategoryAggregate
{
    public class ProductCategory : PriorityEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public Guid? ParentId { get; private set; }
        public string Code { get; private set; }
        public string SiteTitle { get; private set; }
        public string Slug { get; private set; }
        public string MetaKeywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Description { get; private set; }

        public virtual ProductCategory Parent { get; private set; }
        public virtual IEnumerable<ProductCategory> Children { get; private set; }
        public virtual IEnumerable<Product> Products { get; private set; }

        protected ProductCategory()
        {
        }

        public ProductCategory(string name, Guid? parentId) : this()
        {
            Name = name;
            ParentId = parentId;
        }

        public void Update(string name)
        {
            Name = name;
        }

        public void MoveTo(Guid? parentId)
        {
            ParentId = parentId;
        }
    }
}
