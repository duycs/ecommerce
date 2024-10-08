using ECommerce.Shared.SeedWork;
using System;

namespace ECommerce.Domain.AggregateModels.LocationAggregate
{
    public class Ward : PriorityEntity
    {
        public Guid DistrictId { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Location { get; private set; }
        public virtual District District { get; private set; }

        protected  Ward() { }

    }
}
