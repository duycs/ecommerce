using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class Ward
    {
        public Ward()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            Shops = new HashSet<Shop>();
        }

        public Guid Id { get; set; }
        public Guid DistrictId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Priority { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
