using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Write.Commands.Orders
{
    public class CancelOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public CancelOrderCommand() { }

        public CancelOrderCommand(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
