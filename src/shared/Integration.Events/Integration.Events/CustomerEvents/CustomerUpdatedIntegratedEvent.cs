using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Events.CustomerEvents
{
    public class CustomerUpdatedIntegratedEvent : IntegrationEvent
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
