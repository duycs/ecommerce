using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.Write.Commands
{
    public class SyncCustomersLiabilitiesCommand : IRequest
    {
        public IEnumerable<CustomerAndLiabilities> Items { get; set; }
    }

    public class CustomerAndLiabilities
    {
        public uint Id { get; set; }
        public decimal Liabilities { get; set; }
        public decimal MaxLiabilities { get; set; }
    }
}
