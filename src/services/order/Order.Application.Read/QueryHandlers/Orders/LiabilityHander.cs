using Dapper;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Shared.Configurations;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Helpers;
using MediatR;
using Order.Application.Models.Orders;
using Order.Application.Read.Queries.Orders;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Read.QueryHandlers.Orders
{
    public class LiabilityHander : IRequestHandler<ListLiabilityQuery, QueryResult<LiabilityDto>>
    {
        private readonly IDbConnection _dbConnection;
        private CustomHttpClient _httpClient;

        public LiabilityHander(IDbConnection dbConnection, CustomHttpClient httpClient)
        {
            _dbConnection = dbConnection;
            _httpClient = httpClient;
        }

        public async Task<QueryResult<LiabilityDto>> Handle(ListLiabilityQuery request, CancellationToken cancellationToken)
        {
            var template = new SqlBuilder().AddTemplate("select old_id from integration.customer_mappings where customer_id = @CustomerId");
            var customerIdSaas = _dbConnection.QueryFirstOrDefault<int?>(template.RawSql, request);
            if (customerIdSaas == null)
                return new QueryResult<LiabilityDto>();

            var response = await _httpClient.GetAsync(UrlsConfig.SaasMethods.Liability(customerIdSaas.Value) + $"?skip={request.Skip}&take={request.Take}");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsObjectAsync<QueryResult<LiabilityDto>>();

            return data;

        }
    }
}
