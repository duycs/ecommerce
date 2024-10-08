using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class IntProductPrice
    {
        public int? Id { get; set; }
        public string Sku { get; set; }
        public double? PriceWholesale { get; set; }
        public double? PriceRetail { get; set; }
    }
}
