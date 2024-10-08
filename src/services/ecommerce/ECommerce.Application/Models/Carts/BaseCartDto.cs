using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Carts
{
    public abstract class BaseCartDto 
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Note { get; set; }
    }
}
