using ECommerce.Application.Models.Carts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.Carts
{
    public class TotalQuantityDetailsQuery : IRequest<uint>
    {
        public Guid CustomerId { get; set; }

        public TotalQuantityDetailsQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
