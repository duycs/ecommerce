
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration.Domain.AggregateModels
{
    [Table("attribute_mappings", Schema = "integration")]
    public class AttributeMapping
    {
        public Guid AttributeValueId { get; private set; }
        public uint OldId { get; private set; }

        protected AttributeMapping() { }
    }
}
