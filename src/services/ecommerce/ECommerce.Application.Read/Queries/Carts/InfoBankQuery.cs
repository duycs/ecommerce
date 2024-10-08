using ECommerce.Application.Models.Carts;
using ECommerce.Application.Models.Shops;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Read.Queries.Carts
{
    public class InfoBankQuery : IRequest<InforBankDto>
    {

        public InfoBankQuery()
        {
        }
    }
}
