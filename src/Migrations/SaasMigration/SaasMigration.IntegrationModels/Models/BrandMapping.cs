using System;
using System.Collections.Generic;

namespace SaasMigration.IntegrationModels.Models
{
    public partial class BrandMapping
    {
        public Guid BrandId { get; set; }
        public long OldId { get; set; }
    }
}
