using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Write.Commands.Customers
{
    public class UpdateCustomerCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CustomerId { get; set; }
    }
}
