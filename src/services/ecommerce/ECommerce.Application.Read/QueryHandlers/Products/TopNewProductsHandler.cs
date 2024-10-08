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
    public class TopNewProductsHandler : IRequestHandler<TopNewProductsQuery, QueryResult<TopProductDto>>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IProductUtilities _productUtilities;

        public TopNewProductsHandler(IDbConnection dbConnection, IProductUtilities productUtilities)
        {
            _dbConnection = dbConnection;
            _productUtilities = productUtilities;
        }

        public async Task<QueryResult<TopProductDto>> Handle(TopNewProductsQuery request,
            CancellationToken cancellationToken)
        {

            var top = await _productUtilities.GetConfig(ConfigKeys.TopNewProduct);
            var items = await _productUtilities.GetTopProduct(ProductType.New.Id, top);
            return new QueryResult<TopProductDto>(0, items);

        }
    }
}