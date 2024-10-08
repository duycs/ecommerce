using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.RequestModels
{
    public class CreateOrderRequest
    {
        public uint CustomerId { get; set; }
        public string Note { get; set; }
        public IEnumerable<CreateOrderDetailtRequest> ChildrenProducts { get; set; }
    }

    public class CreateOrderDetailtRequest
    {
        public uint Id { get; set; }
        public uint Quantity { get; set; }
    }
}
