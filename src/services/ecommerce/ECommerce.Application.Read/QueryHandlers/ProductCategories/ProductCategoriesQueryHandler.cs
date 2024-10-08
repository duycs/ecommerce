using Dapper;
using ECommerce.Application.Models.ProductCategories;
using ECommerce.Application.Read.Queries.ProductCategories;
using ECommerce.Shared.Dotnet.SQLBuilder;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.ProductCategories
{
    public class ProductCategoriesQueryHandler : IRequestHandler<ProductCategoriesQuery, IEnumerable<ProductCategoryDto>>
    {
        private readonly IDbConnection _dbConnection;

        public ProductCategoriesQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ProductCategoryDto>> Handle(ProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var builderTemplate = builder.AddTemplate("SELECT id, name, image, priority FROM product_categories /**where**/ /**orderby**/");
            builder.Where("parent_id  is null");
            builder.OrderBy(NpgsqlBuilder.Order("product_categories", "priority"));

                var items = await _dbConnection.QueryAsync<ProductCategoryDto>(builderTemplate.RawSql);
            return items;

        }
    }
}
