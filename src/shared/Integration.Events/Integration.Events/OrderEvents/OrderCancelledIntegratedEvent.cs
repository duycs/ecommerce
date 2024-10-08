using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Events.OrderEvents
{
    public class OrderCancelledIntegratedEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public IEnumerable<OrderDetailCancelledIntegratedEvent> Details { get; set; }
    }

    public class OrderDetailCancelledIntegratedEvent
    {
        public Guid ProductChildId { get; set; }
        public uint Quantity { get; set; }
    }

}
