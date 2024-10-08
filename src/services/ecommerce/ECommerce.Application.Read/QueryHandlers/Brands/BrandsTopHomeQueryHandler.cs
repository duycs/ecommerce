using Dapper;
using ECommerce.Application.Models.Brands;
using ECommerce.Application.Read.Queries.Brands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce.Application.Read.QueryHandlers.Brands
{
    public class BrandsTopHomeQueryHandler : IRequestHandler<BrandsTopHomeQuery, IEnumerable<BrandsTopHomeDto>>
    {
        private readonly IDbConnection _dbConnection;

        public BrandsTopHomeQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<BrandsTopHomeDto>> Handle(BrandsTopHomeQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder().AddTemplate(@"
                                        SELECT
                                            id, name , image , priority 
                                        FROM
                                            brands
                                        ORDER BY priority ASC
                                        LIMIT @Top;");

            IEnumerable<BrandsTopHomeDto> brandsTopHome =
                    await _dbConnection.QueryAsync<BrandsTopHomeDto>(builder.RawSql, new {Top = 10});

            return brandsTopHome;
        }
    }
}
