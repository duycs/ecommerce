using Dapper;
using ECommerce.Application.Models.Carts;
using ECommerce.Application.Models.Shops;
using ECommerce.Application.Read.Queries.Carts;
using ECommerce.Shared.Constant;
using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.Carts
{
    public class BankShopQueryHandler : IRequestHandler<InfoBankQuery, InforBankDto>
    {
        private readonly IDbConnection _dbConnection;

        public BankShopQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<InforBankDto> Handle(InfoBankQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();

            var template = builder.AddTemplate(@"
                            SELECT 
	                            account_holder, name, number_account, branch_name
                            FROM shop_bank_accounts;
                            	SELECT 
 	                             value
                             FROM  
 	                            system_configurations WHERE key = @SuggestTransferContents LIMIT 1;
                            ");

            var result = await _dbConnection.QueryMultipleAsync(template.RawSql, new
            {
                SuggestTransferContents = ConfigKeys.SuggestTransferContents
            });

            var bankShops = result.Read<BankShopDto>();
            var tranferContents = result.ReadFirstOrDefault<string>();

            return new InforBankDto(bankShops, tranferContents);
        }
    }
}
