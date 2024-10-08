using ECommerce.Shared.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.DomainEvents
{
    public class OrderStatusChangedDomainEvent : INotification
    {
        public Guid OrderId { get; private set; }
        public string SaasCode { get; private set; }
        public OrderStatus LastStatus { get; private set; }
        public OrderStatus CurrentStatus { get; private set; }
        public Guid CustomerId { get; private set; }

        public OrderStatusChangedDomainEvent(Guid orderId, string saasCode, OrderStatus lastStatus, OrderStatus currentStatus, Guid customerId)
        {
            OrderId = orderId;
            SaasCode = saasCode;
            LastStatus = lastStatus;
            CurrentStatus = currentStatus;
            CustomerId = customerId;
        }
    }
}
