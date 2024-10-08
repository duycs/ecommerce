using Dapper;
using ECommerce.Application.Models.ProductCategories;
using ECommerce.Application.Read.Queries.ProductCategories;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Shared.Dotnet.SQLBuilder;
using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.ProductCategories
{
    public class ListProductCategoriesHandler : IRequestHandler<ListProductCategoriesQuery, QueryResult<ProductCategoryDto>>
    {
        private readonly IDbConnection _dbConnection;

        public ListProductCategoriesHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<QueryResult<ProductCategoryDto>> Handle(ListProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();

            var countTemplate = builder.AddTemplate(@"SELECT count(id) FROM product_categories;");
            var itemsTemplate = builder.AddTemplate(@"SELECT * FROM product_categories /**where**/ /**orderby**/ offset @Skip rows fetch next @Take row only;");

            builder.OrderBy(NpgsqlBuilder.Order("product_categories", "priority"));

            var result = await _dbConnection.QueryMultipleAsync($@"{countTemplate.RawSql}{itemsTemplate.RawSql}", request);

            var count = result.ReadFirst<int>();
            var items = result.Read<ProductCategoryDto>();

            return new QueryResult<ProductCategoryDto>(count, items);
        }
    }
}
