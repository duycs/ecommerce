using Dapper;
using ECommerce.Shared.Enum;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.Helpers.Utils;
using EventBus.Abstractions;
using Integration.Events.OrderEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scheduler.Jobs.CronJobs.SyncJobs;
using Synchronize.BackgroundTasks.Helpers;
using Synchronize.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Synchronize.BackgroundTasks.SyncJobs
{
    public class SyncOrderStatusJob : ISyncOrderStatusJob
    {
        private readonly IEComDbConnection _ecomConn;
        private readonly ISaasDbConnection _saasConn;
        private readonly ISynchronizeUnitOfWork _uow;
        private readonly ECommerceDbContext _ecomDbContext;
        private readonly int BatchSize;
        private readonly IEventBus _eventBus;

        public SyncOrderStatusJob(IEComDbConnection ecomConn, ISaasDbConnection saasConn, ISynchronizeUnitOfWork uow, ECommerceDbContext ecomDbContext, IOptionsSnapshot<SynchronizeConfigurations> options, IEventBus eventBus)
        {
            _ecomConn = ecomConn;
            _saasConn = saasConn;
            _uow = uow;
            _ecomDbContext = ecomDbContext;
            BatchSize = options.Value?.BatchSize ?? 1000;
            _eventBus = eventBus;
        }

        public async Task Run()
        {
            await AsyncIterator<(Guid, uint)>
                .From(async (skip, take) => await _ecomConn.QueryAsync<(Guid, uint)>(@"select order_id, old_id from integration.order_mappings order by old_id offset @Skip rows fetch next @Take rows only", new
                {
                    Skip = skip,
                    Take = take
                }))
                .WithChunkSize(BatchSize)
                .ForChunk(async mappings =>
                {
                    var orderStatus = await _saasConn.QueryAsync<(uint, string, string)>(@"select Id, StatusCode, OrderCode from _customer_order where !IsDeleted and Id in @Ids", new
                    {
                        Ids = mappings.Select(x => x.Item2).ToArray(),
                    });
                    var orderIds = mappings.Where(a => orderStatus.Select(b => b.Item1).Contains(a.Item2)).Select(a => a.Item1);
                    var orders = await _ecomDbContext.Orders.Where(a => orderIds.Contains(a.Id)).ToListAsync();
                    foreach (var order in orders)
                    {
                        var mapping = mappings.First(a => a.Item1 == order.Id).Item2;
                        var saasOrder = orderStatus.First(a => a.Item1 == mapping);
                        var status = GetStatus(saasOrder.Item2);
                        var lastStatus = order.Status;
                        var isChangedStatus = order.UpdateStatus(status);
                        var isChangedCode = order.UpdateCode(saasOrder.Item3);
                        if (isChangedStatus || isChangedCode)
                        {
                            _ecomDbContext.Orders.Update(order);
                            if (isChangedStatus)
                            {
                                _eventBus.Publish(new OrderStatusChangedIntegratedEvent()
                                {
                                    OrderId = order.Id,
                                    SaasCode = order.SaasCode,
                                    LastStatus = lastStatus,
                                    CurrentStatus = status.Id,
                                    UserId = order.CustomerId
                                });
                            }
                        }
                    }
                });

            await _uow.SaveChangesAsync();
        }

        private OrderStatus GetStatus(string status)
        {
            switch (status)
            {
                case "waiting_process":
                    return OrderStatus.Pending;
                case "order_making":
                case "payment_waiting":
                    return OrderStatus.Executing;
                case "waiting_export":
                    return OrderStatus.Shipping;
                case "completed":
                    return OrderStatus.Completed;
                case "cancel":
                    return OrderStatus.Cancel;
                default:
                    return null;
            }
        }
    }
}
