using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Carts
{
    public abstract class BaseCartDetailDto 
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
