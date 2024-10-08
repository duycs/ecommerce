using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Synchronize.Domain.IntegrationAggregate
{
    [Table("child_product_mappings", Schema = "integration")]
    public class ChildProductMapping
    {
        [Key]
        public Guid ChildProductId { get; private set; }
        public uint OldId { get; private set; }

        protected ChildProductMapping() { }

        public ChildProductMapping(Guid childProductId, uint oldId)
        {
            ChildProductId = childProductId;
            OldId = oldId;
        }
    }
}
