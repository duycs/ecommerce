using System;
using System.Collections.Generic;

namespace SaasMigration.IntegrationModels.Models
{
    public partial class ChildProductMapping
    {
        public Guid ChildProductId { get; set; }
        public long OldId { get; set; }
    }
}
