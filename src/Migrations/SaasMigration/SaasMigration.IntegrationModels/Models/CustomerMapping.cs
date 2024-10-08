using System;
using System.Collections.Generic;

namespace SaasMigration.IntegrationModels.Models
{
    public partial class CustomerMapping
    {
        public Guid CustomerId { get; set; }
        public long OldId { get; set; }
    }
}
