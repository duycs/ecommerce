using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Write.Commands.Orders
{
    public class ChangeInfoCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public string Note { get; set; }

        public ChangeInfoCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
