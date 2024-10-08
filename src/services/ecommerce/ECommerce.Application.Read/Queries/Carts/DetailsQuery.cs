using ECommerce.Application.Models.Carts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.Carts
{
    public class DetailsQuery : IRequest<IEnumerable<AttributeValueDto>>
    {
        public Guid CustomerId { get; private set; }

        public DetailsQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
