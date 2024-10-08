using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Products
{
    public class SearchProductDto : BaseProductDto
    {
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public uint TotalQuantityInStock { get; set; }

    }
}
