using Dapper;
using ECommerce.Application.Models.Customers;
using ECommerce.Application.Read.Queries.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.Customers
{
    public class CustomerCurrentLiabilitiesQueryHandler :IRequestHandler<CustomerCurrentLiabilitiesQuery, CustomerCurrentLiabilitiesDto>
    {
        private IDbConnection _dbConnection;

        public CustomerCurrentLiabilitiesQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<CustomerCurrentLiabilitiesDto> Handle(CustomerCurrentLiabilitiesQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();

            var itemTemplate = builder.AddTemplate(@"SELECT id, liabilities, max_liabilities FROM customers 
                                                    WHERE id = @id", new {Id = request.Id});


            CustomerCurrentLiabilitiesDto customer =
                    await _dbConnection.QuerySingleOrDefaultAsync<CustomerCurrentLiabilitiesDto>(itemTemplate.RawSql);

            return customer;
        }
    }
}
