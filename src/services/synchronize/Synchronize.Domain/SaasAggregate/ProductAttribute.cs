using System;
using System.Collections.Generic;
using System.Text;

namespace Synchronize.Domain.SaasAggregate
{
    public class ProductAttribute
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public string TypeCode { get; set; }
    }
}
