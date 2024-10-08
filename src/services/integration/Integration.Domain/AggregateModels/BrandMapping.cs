using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration.Domain.AggregateModels
{
    [Table("brand_mappings", Schema = "integration")]
    public class BrandMapping
    {
        public Guid BrandId { get; private set; }
        public uint OldId { get; private set; }

        protected BrandMapping() { }
    }
}
