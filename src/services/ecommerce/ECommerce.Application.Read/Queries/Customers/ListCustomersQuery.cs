using ECommerce.Application.Models.Customers;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;

namespace ECommerce.Application.Read.Queries.Customers
{
    public class ListCustomersQuery : IRequest<QueryResult<CustomerDto>>
    {
        public int Skip { get; private set; }
        public int Take { get; private set; }

        public ListCustomersQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
