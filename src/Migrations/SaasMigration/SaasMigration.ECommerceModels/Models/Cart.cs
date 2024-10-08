using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetails = new HashSet<CartDetail>();
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
