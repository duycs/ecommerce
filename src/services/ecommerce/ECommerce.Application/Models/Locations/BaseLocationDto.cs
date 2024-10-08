using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Locations
{
    public class BaseLocationDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
