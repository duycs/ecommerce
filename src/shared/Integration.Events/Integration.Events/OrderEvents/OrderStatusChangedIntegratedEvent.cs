using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Events.OrderEvents
{
    public class OrderStatusChangedIntegratedEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public string SaasCode { get; set; }
        public Guid UserId { get; set; }
        public int LastStatus { get; set; }
        public int CurrentStatus { get; set; }
    }
}
