using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.ProductAttributes
{    public abstract class BaseProductAttributeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public int Priority { get; set; }
    }
}
