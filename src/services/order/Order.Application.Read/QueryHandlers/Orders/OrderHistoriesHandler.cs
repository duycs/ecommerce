using Dapper;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Shared.Enum;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using MediatR;
using Order.Application.Models.Orders;
using Order.Application.Read.Queries.Orders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Read.QueryHandlers.Orders
{
    public class OrderHistoriesHandler : IRequestHandler<OrderHistoriesQuery, QueryResult<OrderHistoriesDto>>,
                                            IRequestHandler<OrderDetailQuery, QueryResult<OrderDto>>,
                                            IRequestHandler<OrderHistoryStatusQuery, QueryResult<OrderDto>>
    {
        private readonly IDbConnection _dbConnection;

        public OrderHistoriesHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<QueryResult<OrderHistoriesDto>> Handle(OrderHistoriesQuery request, CancellationToken cancellationToken)
        {
            if (request.FromDate > request.ToDate)
                throw new BusinessRuleException(ECommerceBusinessRule.InvalidInput);
            var builder = new SqlBuilder();
            request.SetToDate();

            var orderTemplate = builder.AddTemplate($@"SELECT  id, status FROM   ""order"".orders /**where**/");
            builder.Where("customer_id = @customerId");
            if (!string.IsNullOrWhiteSpace(request.OrderCode))
            {
                builder.Where("saas_code ILIKE @orderCodeFillter");
            }
            if (request.FromDate != null)
            {
                builder.Where("date_time_order >= @fromDate");
            }
            if (request.ToDate != null)
            {
                builder.Where("date_time_order <= @toDate");
            }

            var orders = (await _dbConnection.QueryAsync<(Guid id, int statusId)>(orderTemplate.RawSql, request)).ToList();
            var orderIds = orders.Select(r => r.id).ToList();
            var orderDetailTemplate = new SqlBuilder().AddTemplate(@$"  SELECT  order_id ,SUM(quantity) as totalQuanlity, SUM(quantity*price)
                                                                        FROM    ""order"".order_details
                                                                        WHERE   order_id = ANY(@Ids)
                                                                        GROUP BY    order_id");
            var resultOrderDetail = _dbConnection.Query<(Guid orderId, int totalQuantity, decimal totalPrice)>(orderDetailTemplate.RawSql, new { Ids = orderIds }).ToList();


            var resultRaw = (from a in orders
                             join b in resultOrderDetail on a.id equals b.orderId into bb
                             from b in bb.DefaultIfEmpty()
                             select a.statusId).ToList();

            var result = new List<OrderHistoriesDto>
            {
                new OrderHistoriesDto(OrderStatus.Pending, resultRaw.Count(r => r == OrderStatus.Pending.Id)),
                new OrderHistoriesDto(OrderStatus.Executing, resultRaw.Count(r => r == OrderStatus.Executing.Id)),
                new OrderHistoriesDto(OrderStatus.Shipping, resultRaw.Count(r => r == OrderStatus.Shipping.Id)),
                new OrderHistoriesDto(OrderStatus.Completed, resultRaw.Count(r => r == OrderStatus.Completed.Id)),
                new OrderHistoriesDto(OrderStatus.Cancel, resultRaw.Count(r => r == OrderStatus.Cancel.Id))
            };

            return new QueryResult<OrderHistoriesDto>(0, result);

        }


        public async Task<QueryResult<OrderDto>> Handle(OrderHistoryStatusQuery request, CancellationToken cancellationToken)
        {

            if (request.FromDate > request.ToDate || request.StatusId == 0)
                throw new BusinessRuleException(ECommerceBusinessRule.InvalidInput);
            var builder = new SqlBuilder();

            request.SetToDate();

            var orderTemplate = builder.AddTemplate(@$"SELECT  id, saas_code AS orderCode,
                                                                customer_name  AS delivery_name, customer_phone  AS delivery_phone,
                                                                customer_address AS delivery_address,
                                                                date_time_order AS orderDate, carriage_number, 
                                                                discount_price, payment_method,
                                                                staff_name, staff_phone, status, note
                                                        FROM    ""order"".orders /**where**/");

            builder.Where("customer_id = @customerId");
            builder.Where("status = @statusId");
            if (!string.IsNullOrWhiteSpace(request.OrderCode))
            {
                builder.Where("saas_code ILIKE @orderCodeFillter");
            }
            if (request.FromDate != null)
            {
                builder.Where("date_time_order >= @fromDate");
            }
            if (request.ToDate != null)
            {
                builder.Where("date_time_order <= @toDate");
            }


            var orders = (await _dbConnection.QueryAsync<OrderDto>(orderTemplate.RawSql, request)).ToList();
            var orderIds = orders.Select(r => r.Id).ToList();
            var orderDetailTemplate = new SqlBuilder().AddTemplate(@$"  SELECT  order_id ,SUM(quantity) AS totalQuanlity, SUM(quantity*price)
                                                                        FROM    ""order"".order_details
                                                                        WHERE   order_id = ANY(@Ids)
                                                                        GROUP BY    order_id");
            var resultOrderDetail = _dbConnection.Query<(Guid orderId, int totalQuantity, decimal totalPrice)>(orderDetailTemplate.RawSql, new { Ids = orderIds }).ToList();


            var resultRaw = from a in orders
                            join b in resultOrderDetail on a.Id equals b.orderId into bb
                            from b in bb.DefaultIfEmpty()
                            select new OrderDto
                            {
                                Id = a.Id,
                                OrderCode = a.OrderCode,
                                CarriageNumber = a.CarriageNumber,
                                DeliveryAddress = a.DeliveryAddress,
                                DeliveryName = a.DeliveryName,
                                DeliveryPhone = a.DeliveryPhone,
                                OrderDate = a.OrderDate,
                                TotalQuantity = b.totalQuantity,
                                TotalMoneyTemp = b.totalPrice,
                                DiscountPrice = a.DiscountPrice,
                                PaymentMethod = a.PaymentMethod,
                                StaffName = a.StaffName,
                                StaffPhone = a.StaffPhone,
                                Status = a.Status,
                                Note = a.Note
                            };

            return new QueryResult<OrderDto>(orders.Count, resultRaw);
        }

        public async Task<QueryResult<OrderDto>> Handle(OrderDetailQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var orderTemplate = builder.AddTemplate($@" SELECT  id, saas_code AS orderCode,
                                                                customer_name AS delivery_name, customer_phone as delivery_phone, customer_address as delivery_address ,
                                                                date_time_order as orderDate, carriage_number, 
                                                                discount_price, payment_method,
                                                                staff_name, staff_phone, status, note
                                                        FROM    ""order"".orders
                                                        WHERE   customer_id = @customerId AND
                                                                id = @id");

            var orders = (await _dbConnection.QueryAsync<OrderDto>(orderTemplate.RawSql, request)).ToList();
            var orderIds = orders.Select(r => r.Id).ToList();
            var orderDetailTemplate = new SqlBuilder().AddTemplate(@$"  SELECT  order_id ,SUM(quantity) as totalQuanlity, SUM(quantity*price)
                                                                        FROM    ""order"".order_details
                                                                        WHERE   order_id = ANY(@Ids)
                                                                        GROUP BY    order_id");
            var resultOrderDetail = _dbConnection.Query<(Guid orderId, int totalQuantity, decimal totalPrice)>(orderDetailTemplate.RawSql, new { Ids = orderIds }).ToList();


            var resultRaw = from a in orders
                            join b in resultOrderDetail on a.Id equals b.orderId into bb
                            from b in bb.DefaultIfEmpty()
                            select new OrderDto
                            {
                                Id = a.Id,
                                OrderCode = a.OrderCode,
                                CarriageNumber = a.CarriageNumber,
                                DeliveryAddress = a.DeliveryAddress,
                                DeliveryName = a.DeliveryName,
                                DeliveryPhone = a.DeliveryPhone,
                                OrderDate = a.OrderDate,
                                TotalQuantity = b.totalQuantity,
                                TotalMoneyTemp = b.totalPrice,
                                DiscountPrice = a.DiscountPrice,
                                PaymentMethod = a.PaymentMethod,
                                StaffName = a.StaffName,
                                StaffPhone = a.StaffPhone,
                                Status = a.Status,
                                Note = a.Note
                            };

            return new QueryResult<OrderDto>(0, resultRaw);
        }
    }
}
