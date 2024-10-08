using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Integration.Domain.AggregateModels
{
    [Table("child_product_mappings", Schema = "integration")]
    public class ChildProductMapping
    {
        public Guid ChildProductId { get; private set; }
        public uint OldId { get; private set; }

        protected ChildProductMapping() { }
    }
}
