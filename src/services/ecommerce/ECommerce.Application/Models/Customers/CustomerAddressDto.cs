using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Customers
{
    public class CustomerAddressDto
    {
        public Guid Id { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public Guid? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public Guid? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid? WardId { get; set; }
        public string WardName { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }

    }
}
