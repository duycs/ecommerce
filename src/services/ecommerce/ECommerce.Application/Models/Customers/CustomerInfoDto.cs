using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Customers
{
    public class CustomerInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ExtraPhoneNumbers { get; set; }
        public DateTime? DOB { get; set; }
        public string Email { get; set; }
        public int? Gender { get; set; }
        public string Avatar { get; set; }
        public decimal Liabilities { get; set; }
        public decimal MaxLiabilities { get; set; }
        public CustomerAddressDto Address { get; set; }
    }
}
