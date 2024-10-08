using ECommerce.Shared.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration.Domain.AggregateModels
{
    [Table("order_mappings", Schema = "integration")]
    public class OrderMapping : IAggregateRoot
    {
        public Guid OrderId { get; private set; }
        public uint OldId { get; private set; }

        protected OrderMapping() { }

        public OrderMapping(Guid orderId, uint oldId)
        {
            OrderId = orderId;
            OldId = oldId;
        }
    }
}
