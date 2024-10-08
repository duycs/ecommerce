using Dapper;
using ECommerce.Application.Models.Carts;
using ECommerce.Application.Read.Queries.Carts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace ECommerce.Application.Read.QueryHandlers.Carts
{
    public class TotalQuantityDetailsQueryHandler : IRequestHandler<TotalQuantityDetailsQuery, uint>
    {
        private IDbConnection _dbConnection;

        public TotalQuantityDetailsQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<uint> Handle(TotalQuantityDetailsQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();

            var template = builder.AddTemplate(@"
                                SELECT sum(cart_details.quantity) FROM 
 	                                (SELECT id FROM carts WHERE customer_id = @CustomerId) cart
                                INNER JOIN cart_details ON cart.id = cart_details.cart_id
                                GROUP BY cart.id LIMIT 1");

            var result = await _dbConnection.QueryFirstOrDefaultAsync<uint>(template.RawSql, request);

            return result;
        }
    }
}
