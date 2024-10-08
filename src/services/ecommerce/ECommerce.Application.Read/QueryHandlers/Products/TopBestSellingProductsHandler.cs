using ECommerce.Application.Models.Products;
using ECommerce.Application.Read.Queries.Products;
using ECommerce.Application.ServiceInterfaces.HandlerInterface;
using ECommerce.Domain.Enums;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.Products
{
    public class
        TopBestSellingProductsHandler : IRequestHandler<TopBestSellingProductsQuery, QueryResult<TopProductDto>>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IProductUtilities _productUtilities;

        public TopBestSellingProductsHandler(IDbConnection dbConnection, IProductUtilities productUtilities)
        {
            _dbConnection = dbConnection;
            _productUtilities = productUtilities;
        }

        public async Task<QueryResult<TopProductDto>> Handle(TopBestSellingProductsQuery request,
            CancellationToken cancellationToken)
        {
            var top = await _productUtilities.GetConfig(ConfigKeys.TopBestSellingProduct);
            var items = await _productUtilities.GetTopProduct(ProductType.BestSelling.Id, top);
            return new QueryResult<TopProductDto>(0, items);
        }
    }
}