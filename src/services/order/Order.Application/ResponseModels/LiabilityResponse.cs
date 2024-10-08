using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.ResponseModels
{
    public class LiabilityResponse
    {
        public decimal AmountChange { get; set; }
        public string Description { get; set; }
        public decimal Liabilities { get; set; }
        public int CreatedTime { get; set; }
    }
}
