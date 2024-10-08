using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Events.OrderEvents
{
    public class OrderNoteUpdatedIntegratedEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public string Note { get; set; }
    }
}
