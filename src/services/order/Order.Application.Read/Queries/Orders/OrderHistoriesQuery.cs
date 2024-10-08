using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Order.Application.Models.Orders;
using System;

namespace Order.Application.Read.Queries.Orders
{
    public class OrderHistoriesQuery : IRequest<QueryResult<OrderHistoriesDto>>
    {
        public OrderHistoriesQuery() { }
        public OrderHistoriesQuery(DateTime? fromDate, DateTime? toDate, string orderCode, Guid customerId)
        { 
            FromDate = fromDate;
            ToDate = toDate;
            OrderCode = orderCode;
            CustomerId = customerId;
        }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string OrderCode { get; set; }
        public string OrderCodeFillter => $"%{OrderCode}%";
        public Guid CustomerId { get; set; }

        public void SetToDate()
        {
            if (ToDate != null)
            {
                ToDate = ToDate.Value.AddDays(1);
            }
        }

    }
}
