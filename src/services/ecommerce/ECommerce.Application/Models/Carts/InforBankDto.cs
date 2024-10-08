using ECommerce.Application.Models.Shops;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Carts
{
    public class InforBankDto
    {
        public IEnumerable<BankShopDto> BankShops { get; set; }
        public string TransferContents { get; set; }

        public InforBankDto(IEnumerable<BankShopDto> bankShops, string transferContents)
        {
            BankShops = bankShops;
            TransferContents = transferContents;
        }
    }
}
