using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class CartDetail
    {
        public Guid CartId { get; set; }
        public Guid ProductChildId { get; set; }
        public long Quantity { get; set; }
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public decimal Price { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual ProductChild ProductChild { get; set; }
    }
}
