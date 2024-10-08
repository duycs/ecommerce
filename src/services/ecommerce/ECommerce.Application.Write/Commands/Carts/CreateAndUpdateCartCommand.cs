using ECommerce.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Write.Commands.Carts
{
    public class CreateAndUpdateCartCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public List<Item> Items { get; set; }

        public CreateAndUpdateCartCommand(Guid customerId, List<Item> items)
        {
            CustomerId = customerId;
            Items = items;
        }
    }
}
