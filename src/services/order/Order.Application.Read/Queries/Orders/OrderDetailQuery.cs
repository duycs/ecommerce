using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Order.Application.Models.Orders;
using System;

namespace Order.Application.Read.Queries.Orders
{
    public class OrderDetailQuery : IRequest<QueryResult<OrderDto>>
    {
        public OrderDetailQuery(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}
