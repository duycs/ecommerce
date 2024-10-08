using System;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Order.Application.Models.Orders;

namespace Order.Application.Read.Queries.Orders
{
    public class ProductsInOrderQuery : IRequest<QueryResult<ProductInOrderDto>>
    {
        public ProductsInOrderQuery(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}
