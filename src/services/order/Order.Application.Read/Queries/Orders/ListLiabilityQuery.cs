using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Order.Application.Models.Orders;
using System;

namespace Order.Application.Read.Queries.Orders
{
    public class ListLiabilityQuery : IRequest<QueryResult<LiabilityDto>>
    {
        public Guid CustomerId { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public ListLiabilityQuery(Guid customerId, int skip, int take)
        {
            CustomerId = customerId;
            Take = take;
            Skip = skip;
        }
    }
}
