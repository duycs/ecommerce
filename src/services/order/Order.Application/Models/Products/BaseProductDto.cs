using System;
using System.Collections.Generic;

namespace Order.Application.Models.Products
{
    public abstract class BaseProductDto
    {
        public Guid Id { get; set; }
        public Guid ShopId { get; set; }
        public string Sku { get; set; }
        public Guid FixedAttributeId { get; set; }
        public Guid InputAttributeId { get; set; }
        public string Name { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string ThumbIamge { get; set; }
        public IList<string> ImageList { get; set; }
        public string ProductSAASId { get; set; }
        public bool IsSellFullSize { get; set; }
    }
}
