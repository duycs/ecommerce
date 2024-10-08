using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.ProductAttributes
{
    public abstract class BaseProductAttributeValueDto
    {
        public Guid Id { get; set; }
        public Guid AttributeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
