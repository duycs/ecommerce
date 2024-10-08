using Dapper;
using ECommerce.Application.Models.Brands;
using ECommerce.Application.Read.Queries.Brands;
using ECommerce.Shared.Dotnet.SQLBuilder;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.Brands
{
    public class BrandsQueryHandler : IRequestHandler<BrandsQuery, IEnumerable<BrandDto>>
    {
        private readonly IDbConnection _dbConnection;

        public BrandsQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<BrandDto>> Handle(BrandsQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();

            var builderTemplate = builder.AddTemplate(@"SELECT id, name, image, priority  FROM brands /**where**/ /**orderby**/");

            builder.OrderBy(NpgsqlBuilder.Order("brands", "priority"));

            IEnumerable<BrandDto> brands = await _dbConnection.QueryAsync<BrandDto>(builderTemplate.RawSql);

            return brands;
        }
    }
}
