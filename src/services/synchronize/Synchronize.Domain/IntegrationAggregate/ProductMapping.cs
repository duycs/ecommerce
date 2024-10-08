using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Synchronize.Domain.IntegrationAggregate
{
    [Table("product_mappings", Schema = "integration")]
    public class ProductMapping
    {
        [Key]
        public Guid ProductId { get; private set; }
        public uint OldId { get; private set; }

        protected ProductMapping() { }

        public ProductMapping(Guid productId, uint oldId)
        {
            ProductId = productId;
            OldId = oldId;
        }
    }
}
