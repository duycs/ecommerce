using Dapper;
using ECommerce.Application.Models.ProductCategories;
using ECommerce.Application.Read.Queries.ProductCategories;
using ECommerce.Application.ServiceInterfaces.HandlerInterface;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Shared.Dotnet.SQLBuilder;
using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.ProductCategories
{
    public class TopProductCategoriesHandler : IRequestHandler<TopProductCategoriesQuery, QueryResult<ProductCategoryDto>>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IProductUtilities _productUtilities;

        public TopProductCategoriesHandler(IDbConnection dbConnection, IProductUtilities productUtilities)
        {
            _dbConnection = dbConnection;
            _productUtilities = productUtilities;
        }

        public async Task<QueryResult<ProductCategoryDto>> Handle(TopProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var top = await _productUtilities.GetConfig(ConfigCategoryKey.TopCategory);
            var builder = new SqlBuilder();

            var itemsTemplate = builder.AddTemplate($@"SELECT id, name, image, priority FROM product_categories /**where**/ /**orderby**/ offset 0 rows fetch next {top} row only;");

            builder.Where(@"parent_id  is null ");

            builder.OrderBy(NpgsqlBuilder.Order("product_categories", "priority"));

            var items = await _dbConnection.QueryAsync<ProductCategoryDto>($@"{itemsTemplate.RawSql}", request);

            return new QueryResult<ProductCategoryDto>(0, items);

        }
    }
}
