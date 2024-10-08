using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration.Domain.AggregateModels
{
    [Table("product_mappings", Schema = "integration")]
    public class ProductMapping
    {
        public Guid ProductId { get; private set; }
        public uint OldId { get; private set; }

        protected ProductMapping() { }
    }
}
