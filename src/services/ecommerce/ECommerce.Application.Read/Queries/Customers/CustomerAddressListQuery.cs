using ECommerce.Application.Models.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.Customers
{
    public class CustomerAddressListQuery : IRequest<IEnumerable<CustomerAddressDto>>
    {
        public Guid CustomerId { get; private set; }

        public CustomerAddressListQuery(Guid id)
        {
            CustomerId = id;
        }
    }
}
