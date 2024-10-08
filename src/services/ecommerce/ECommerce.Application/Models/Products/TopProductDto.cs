using ECommerce.Domain.Enums;
using ECommerce.Shared.SeedWork;
using System;

namespace ECommerce.Application.Models.Products
{
    public class TopProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Image { get; set; }
        public string[] Images { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsSellFullSize { get; set; }
        public int ProductType { get; set; }
        public uint TotalQuantityInStock { get; set; }
        public ProductType ProductTypeName => Enumeration.FromValue<ProductType>(ProductType);
    }
}
