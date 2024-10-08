using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.Write.Commands
{
    public class SyncProductQuantitiesCommand : IRequest
    {
        public IEnumerable<ProductQuantity> Items { get; set; }
    }

    public class ProductQuantity
    {
        public int Id { get; set; }
        public uint Quantity { get; set; }
    }
}
