using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.AggregateModels.ShopAggregate
{
    public class ShopBankAccount : PriorityEntity
    {
        public Guid ShopId { get; private set; }
        public string AccountHolder { get; private set; }
        public string Name { get; private set; }
        public string NumberAccount { get; private set; }
        public string BranchName { get; private set; }

        public virtual Shop Shop { get; private set; }
        protected ShopBankAccount() { }
    }
}
