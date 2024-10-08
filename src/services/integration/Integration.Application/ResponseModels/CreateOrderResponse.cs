using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.ResponseModels
{
    public class CreateOrderResponse
    {
        public uint Id { get; set; }
        public string OrderCode { get; set; }
        public uint CustomerOrderNumber { get; set; }
    }
}
