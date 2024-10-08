using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Order.Application.Models.Orders;
using System;

namespace Order.Application.Read.Queries.Orders
{
    public class OrderHistoryStatusQuery : IRequest<QueryResult<OrderDto>>
    {
        public OrderHistoryStatusQuery() { }
        public OrderHistoryStatusQuery(Guid customerId, DateTime? fromDate, DateTime? toDate, string orderCode, int statusId, int skip, int take)
        {
            FromDate = fromDate;
            ToDate = toDate;
            OrderCode = orderCode;
            Skip = skip;
            Take = take;
            StatusId = statusId;
            CustomerId = customerId;
        }
        public Guid CustomerId { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string OrderCode { get; set; }
        public string OrderCodeFillter => $"%{OrderCode}%";
        public int StatusId { get; set; }

        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;

        public void SetToDate()
        {
            if (ToDate != null)
            {
                ToDate = ToDate.Value.AddDays(1);
            }
        }

    }
}
