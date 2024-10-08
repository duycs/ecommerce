using ECommerce.Shared.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration.Domain.AggregateModels
{
    [Table("customer_mappings", Schema = "integration")]
    public class CustomerMapping : IAggregateRoot
    {
        public Guid CustomerId { get; private set; }
        public uint OldId { get; private set; }

        protected CustomerMapping() { }

        public CustomerMapping(Guid customerId, uint oldId)
        {
            CustomerId = customerId;
            OldId = oldId;
        }
    }
}
