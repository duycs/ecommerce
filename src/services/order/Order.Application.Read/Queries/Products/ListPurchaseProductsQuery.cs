using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Order.Application.Models.Products;
using System;

namespace Order.Application.Read.Queries.Products
{
    public class ListPurchaseProductsQuery : IRequest<QueryResult<ProductPurchaseDto>>
    {
        public Guid CustomerId { get; private set; }
        public int Skip { get; private set; }
        public int Take { get; private set; }
        public ListPurchaseProductsQuery(Guid customerId, int skip, int take = 10)
        {
            CustomerId = customerId;
            Skip = skip;
            Take = take;
        }
    }
}
