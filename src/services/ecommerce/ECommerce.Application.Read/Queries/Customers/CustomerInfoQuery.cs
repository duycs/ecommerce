using ECommerce.Application.Models.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.Customers
{
    public class CustomerInfoQuery : IRequest<CustomerInfoDto>
    {
        public Guid CustomerId { get; private set; }

        public CustomerInfoQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
