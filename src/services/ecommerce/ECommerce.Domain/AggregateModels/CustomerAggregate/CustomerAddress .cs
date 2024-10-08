using ECommerce.Domain.AggregateModels.LocationAggregate;
using ECommerce.Shared.SeedWork;
using System;

namespace ECommerce.Domain.AggregateModels.CustomerAggregate
{
    public class CustomerAddress : DateModiferTrackingEntity
    {
        public Guid CustomerId { get; private set; }
        public string ReceiverName { get; private set; }
        public string ReceiverPhoneNumber { get; private set; }
        public Guid? WardId { get; private set; }
        public string Address { get; private set; }
        public bool IsDefault { get; private set; }

        public virtual Ward Ward { get; private set; }
        public virtual Customer Customer { get; private set; }

        protected CustomerAddress() { }

        public CustomerAddress(string receiverName, string receiverPhoneNumber, Guid? wardId, string address)
        {
            ReceiverName = receiverName;
            ReceiverPhoneNumber = receiverPhoneNumber;
            WardId = wardId;
            Address = address;
        }

        public void Update(string receiverName, string receiverPhoneNumber, Guid? wardId, string address)
        {
            ReceiverName = receiverName;
            ReceiverPhoneNumber = receiverPhoneNumber;
            WardId = wardId;
            Address = address;
        }

        public void SetDefault()
        {
            IsDefault = true;
        }

        public void UnsetDefault()
        {
            IsDefault = false;
        }
    }
}
