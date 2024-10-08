using System;
using System.Collections.Generic;

namespace SaasMigration.ECommerceModels.Models
{
    public partial class Province
    {
        public Province()
        {
            Districts = new HashSet<District>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public string LastUpdatedBy { get; set; }
        public Guid LastUpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Priority { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
