using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Write.Commands.Carts
{
    public class RemoveDetailCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public IList<Guid> Items { get; set; }

        public RemoveDetailCommand(Guid customerId, IList<Guid> items)
        {
            CustomerId = customerId;
            Items = items;
        }
    }
}
