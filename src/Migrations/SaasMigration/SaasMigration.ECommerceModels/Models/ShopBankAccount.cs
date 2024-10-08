using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class ShopBankAccount
    {
        public Guid Id { get; set; }
        public Guid ShopId { get; set; }
        public string AccountHolder { get; set; }
        public string Name { get; set; }
        public string NumberAccount { get; set; }
        public string BranchName { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Priority { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
