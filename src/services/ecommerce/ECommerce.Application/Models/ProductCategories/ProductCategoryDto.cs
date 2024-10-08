using System;

namespace ECommerce.Application.Models.ProductCategories
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Priority { get; set; }
    }
}
