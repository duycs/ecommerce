using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class CustomerAddress
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? WardId { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool? IsDefault { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Ward Ward { get; set; }
    }
}
