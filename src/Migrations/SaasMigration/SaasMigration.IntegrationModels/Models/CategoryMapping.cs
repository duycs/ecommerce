using System;
using System.Collections.Generic;

namespace SaasMigration.IntegrationModels.Models
{
    public partial class CategoryMapping
    {
        public long OldId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
