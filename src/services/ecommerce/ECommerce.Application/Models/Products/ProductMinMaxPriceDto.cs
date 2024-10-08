using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Products
{
    public class ProductMinMaxPriceDto
    {
        public Guid ProductId { get; set; }
        public uint TotalQuantityInStock { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
