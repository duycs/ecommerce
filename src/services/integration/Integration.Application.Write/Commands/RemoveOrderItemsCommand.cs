using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.Write.Commands
{
    public class RemoveOrderItemsCommand : IRequest
    {
        public uint OrderId { get; set; }
        public IEnumerable<uint> ProductChildIds { get; set; }
    }
}
