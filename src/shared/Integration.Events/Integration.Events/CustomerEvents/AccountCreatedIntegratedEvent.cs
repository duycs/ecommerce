using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Events.CustomerEvents
{
    public class AccountCreatedIntegratedEvent : IntegrationEvent
    {
        public Guid? WardId { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid UserId { get; set; }
    }
}
