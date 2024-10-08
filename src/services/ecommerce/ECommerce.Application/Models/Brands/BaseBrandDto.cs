using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Brands
{
    public abstract class BaseBrandDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Priority { get; set; }
    }
}
