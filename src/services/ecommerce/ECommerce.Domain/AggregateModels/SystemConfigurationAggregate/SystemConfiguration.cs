using ECommerce.Shared.SeedWork;

namespace ECommerce.Domain.AggregateModels.SystemConfigurationAggregate
{
    public class SystemConfiguration : PriorityEntity, IAggregateRoot
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected SystemConfiguration()
        {
        }

        public SystemConfiguration(string key, string value) : this()
        {
            Key = key;
            Value = value;
        }

        public SystemConfiguration(string key, string value, string name, string description) : this(key, value)
        {
            Name = name;
            Description = description;
        }
    }
}
