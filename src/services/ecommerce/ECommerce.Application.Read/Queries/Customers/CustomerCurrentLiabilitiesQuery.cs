using ECommerce.Application.Models.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.Customers
{
    public class CustomerCurrentLiabilitiesQuery : IRequest<CustomerCurrentLiabilitiesDto>
    {
        public Guid Id { get; private set; }

        public CustomerCurrentLiabilitiesQuery(Guid id)
        {
            Id = id;
        }
    }
}
