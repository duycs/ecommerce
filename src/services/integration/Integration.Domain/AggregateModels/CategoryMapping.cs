using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Integration.Domain.AggregateModels
{
    [Table("category_mappings", Schema = "integration")]
    public class CategoryMapping
    {
        public Guid CategoryId { get; private set; }
        public uint OldId { get; private set; }

        protected CategoryMapping() { }
    }
}
