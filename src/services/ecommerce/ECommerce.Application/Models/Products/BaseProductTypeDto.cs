using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Products
{
    public abstract class BaseProductTypeDto 
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Priority { get; set; }
        public uint TotalQuantityInStock { get; set; }
    }
}
