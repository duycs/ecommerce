using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Shared.SeedWork;
using System.Collections.Generic;

namespace ECommerce.Domain.AggregateModels.BrandAggregate
{
    public class Brand : PriorityEntity, IAggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string Slug { get; private set; }
        public string MetaKeywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Description { get; private set; }

        public virtual IEnumerable<Product> Products { get; private set; }
    }
}
