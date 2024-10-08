using Dapper;
using ECommerce.Application.Models.Brands;
using ECommerce.Application.Read.Queries.Brands;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using ECommerce.Shared.Dotnet.SQLBuilder;

namespace ECommerce.Application.Read.QueryHandlers.Brands
{
    public class ListBrandsQueryHandler : IRequestHandler<ListBrandsQuery, QueryResult<BrandDto>>
    {
        private readonly IDbConnection _dbConnection;

        public ListBrandsQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<QueryResult<BrandDto>> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();

            var countTemplate = builder.AddTemplate(@"SELECT count(id) FROM brands;");
            var itemsTemplate = builder.AddTemplate(@"SELECT id, name, image, priority FROM brands /**where**/ /**orderby**/ offset @Skip rows fetch next @Take row only;");
            builder.OrderBy(NpgsqlBuilder.Order("brands", "priority"));

            var result = await _dbConnection.QueryMultipleAsync($@"{countTemplate.RawSql}{itemsTemplate.RawSql}", request);

            var count = result.ReadFirst<int>();
            var items = result.Read<BrandDto>();

            return new QueryResult<BrandDto>(count, items);
        }
    }
}
