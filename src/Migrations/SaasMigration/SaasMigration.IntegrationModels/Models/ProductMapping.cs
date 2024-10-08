using System;
using System.Collections.Generic;

namespace SaasMigration.IntegrationModels.Models
{
    public partial class ProductMapping
    {
        public Guid ProductId { get; set; }
        public long OldId { get; set; }
    }
}
