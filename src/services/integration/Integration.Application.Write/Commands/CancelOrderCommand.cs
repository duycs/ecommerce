using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.Write.Commands
{
    public class CancelOrderCommand : IRequest
    {
        public uint OrderId { get; set; }

        public CancelOrderCommand(uint orderId)
        {
            OrderId = orderId;
        }
    }
}
