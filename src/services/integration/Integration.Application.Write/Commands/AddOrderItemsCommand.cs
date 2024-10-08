using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.Write.Commands
{
    public class AddOrderItemsCommand : IRequest
    {
        public uint OrderId { get; set; }
        public IEnumerable<OrderItemCommand> Items { get; set; }
    }
}
