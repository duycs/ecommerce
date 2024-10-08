using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Order.Application.Models.Products;
using System;

namespace Order.Application.Read.Queries.Products
{
    public class TopPurchaseProductsQuery : IRequest<QueryResult<ProductPurchaseDto>>
    {
        public TopPurchaseProductsQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; private set; }
    }
}
