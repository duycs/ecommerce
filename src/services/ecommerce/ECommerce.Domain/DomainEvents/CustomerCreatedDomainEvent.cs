using ECommerce.Domain.AggregateModels.CustomerAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.DomainEvents
{
    public class CustomerCreatedDomainEvent : INotification
    {
        public Customer Customer { get; private set; }

        public CustomerCreatedDomainEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}
