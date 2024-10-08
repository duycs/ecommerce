using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.Write.Commands
{
    public class OrderItemCommand
    {
        public uint ProductChildId { get; set; }
        public uint Quantity { get; set; }
    }
}
