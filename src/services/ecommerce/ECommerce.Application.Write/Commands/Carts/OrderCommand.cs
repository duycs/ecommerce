using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Write.Commands.Carts
{
    public class OrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; private set; }
        public Guid? AddressId { get; set; }

        public void SetCustomerId(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
