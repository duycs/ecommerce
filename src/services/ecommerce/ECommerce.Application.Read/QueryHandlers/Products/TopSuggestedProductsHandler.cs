using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Application.Models.Products;
using ECommerce.Application.Read.Queries.Products;
using ECommerce.Application.ServiceInterfaces.HandlerInterface;
using ECommerce.Domain.Enums;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;

namespace ECommerce.Application.Read.QueryHandlers.Products
{
    public class TopSuggestedProductsHandler : IRequestHandler<TopSuggestedProductsQuery, QueryResult<TopProductDto>>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IProductUtilities _productUtilites;

        public TopSuggestedProductsHandler(IDbConnection dbConnection, IProductUtilities productUtilites)
        {
            _dbConnection = dbConnection;
            _productUtilites = productUtilites;
        }

        public async Task<QueryResult<TopProductDto>> Handle(TopSuggestedProductsQuery request,
            CancellationToken cancellationToken)
        {
            var top = await _productUtilites.GetConfig(ConfigKeys.TopSuggestedProduct);
            var items = await _productUtilites.GetTopProduct(ProductType.Suggested.Id, top);
            return new QueryResult<TopProductDto>(0, items);
        }
    }
}