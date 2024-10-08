using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Products
{
    public class ProducChildtPriceTopHomeDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public uint QuantityInStock { get; set; }

    }
}
