using System;
using System.Collections.Generic;

namespace SaasMigration.IntegrationModels.Models
{
    public partial class OrderMapping
    {
        public Guid OrderId { get; set; }
        public long OldId { get; set; }
    }
}
