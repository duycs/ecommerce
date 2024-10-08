using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Write.Commands.Customers
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid Id { get; private set; }

        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}
