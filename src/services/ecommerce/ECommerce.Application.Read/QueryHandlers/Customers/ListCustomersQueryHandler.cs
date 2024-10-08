using ECommerce.Application.Models.Customers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using ECommerce.Application.Read.Queries.Customers;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Shared.Dotnet.SQLBuilder;

namespace ECommerce.Application.Read.QueryHandlers.Customers
{
    public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, QueryResult<CustomerDto>>
    {
        private readonly IDbConnection _dbConnection;

        public ListCustomersQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<QueryResult<CustomerDto>> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var countTemplate = builder.AddTemplate(@"Select count(id) from customers /**where**/;");
            var itemsTemplate = builder.AddTemplate(@"select * from customers /**where**/ /**orderby**/ offset @Skip rows fetch next @Take row only;");
            builder.OrderBy(NpgsqlBuilder.Order("customers", "created_date"));
            var result = await _dbConnection.QueryMultipleAsync($@"{countTemplate.RawSql}{itemsTemplate.RawSql}", request);
            var count = result.ReadFirst<int>();
            var items = result.Read<CustomerDto>();
            return new QueryResult<CustomerDto>(count, items);
        }
    }
}
