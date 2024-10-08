using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.Write.Commands
{
    public class SyncProductImageCommand : IRequest
    {
        public uint ProductId { get; set; }
        public string[] Images { get; set; }
    }
}
