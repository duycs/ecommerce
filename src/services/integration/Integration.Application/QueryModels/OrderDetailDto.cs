using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Application.QueryModels
{
    public class OrderDetailDto
    {
        public Guid ProductChildId { get; set; }
        public int Quantity { get; set; }
    }
}
