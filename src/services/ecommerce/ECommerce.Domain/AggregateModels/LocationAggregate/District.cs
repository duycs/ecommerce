using ECommerce.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.AggregateModels.LocationAggregate
{
    public class District : PriorityEntity
    {
        public Guid ProvinceId { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Location { get; private set; }

        public virtual Province Province { get; private set; }
        public virtual ICollection<Ward> Wards { get; private set; }
        protected District() { }
    }
}
