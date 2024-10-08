using ECommerce.Shared.SeedWork;
using System.Collections.Generic;

namespace ECommerce.Domain.AggregateModels.LocationAggregate
{
    public class Province : PriorityEntity , IAggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }

        public virtual ICollection<District> Districts { get; private set; }
    }
}
