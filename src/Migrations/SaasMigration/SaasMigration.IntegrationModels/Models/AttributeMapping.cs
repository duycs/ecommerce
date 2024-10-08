using System;
using System.Collections.Generic;

namespace SaasMigration.IntegrationModels.Models
{
    public partial class AttributeMapping
    {
        public Guid AttributeValueId { get; set; }
        public long OldId { get; set; }
    }
}
