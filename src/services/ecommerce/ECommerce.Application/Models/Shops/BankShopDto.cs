using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Shops
{
    public class BankShopDto 
    {
        public string AccountHolder { get; private set; }
        public string Name { get; private set; }
        public string NumberAccount { get; private set; }
        public string BranchName { get; private set; }
    }
}
