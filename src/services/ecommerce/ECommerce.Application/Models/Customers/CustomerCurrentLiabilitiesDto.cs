using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Customers
{
    public class CustomerCurrentLiabilitiesDto
    {
        public Guid Id { get; set; }
        public decimal Liabilities { get; set; }
        public decimal MaxLiabilities { get; set; }
    }
}
