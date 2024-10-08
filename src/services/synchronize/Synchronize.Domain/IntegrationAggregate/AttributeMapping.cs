using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Synchronize.Domain.IntegrationAggregate
{
    [Table("attribute_mappings", Schema = "integration")]
    public class AttributeMapping
    {
        [Key]
        public Guid AttributeValueId { get; private set; }
        public long OldId { get; private set; }

        protected AttributeMapping()
        {
        }

        public AttributeMapping(Guid attributeValueId, long oldId)
        {
            AttributeValueId = attributeValueId;
            OldId = oldId;
        }
    }
}
