using Dapper;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.Helpers.Utils;
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
    public class SyncOrderStaffJob : ISyncOrderStaffJob
    {
        private readonly IEComDbConnection _ecomConn;
        private readonly ISaasDbConnection _saasConn;
        private readonly ISynchronizeUnitOfWork _uow;
        private readonly ECommerceDbContext _ecomDbContext;
        private readonly int BatchSize;

        public SyncOrderStaffJob(IEComDbConnection ecomConn, ISaasDbConnection saasConn, ISynchronizeUnitOfWork uow, ECommerceDbContext ecomDbContext, IOptionsSnapshot<SynchronizeConfigurations> options)
        {
            _ecomConn = ecomConn;
            _saasConn = saasConn;
            _uow = uow;
            _ecomDbContext = ecomDbContext;
            BatchSize = options.Value?.BatchSize ?? 1000;
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
                    var orderDetails = await _saasConn.QueryAsync<(uint, string, string)>(@"select co.Id, su.FullName, su.PhoneNumber from _customer_order co
                        join _system_user su on co.SupportUserId = su.Id
                        where !co.IsDeleted and co.IsActivated and !su.IsDeleted and su.IsActive && co.Id in @Ids", new
                    {
                        Ids = mappings.Select(x => x.Item2).ToArray(),
                    });
                    var orderIds = mappings.Where(a => orderDetails.Select(b => b.Item1).Contains(a.Item2)).Select(a => a.Item1);
                    var orders = await _ecomDbContext.Orders.Where(a => orderIds.Contains(a.Id)).ToListAsync();
                    foreach (var order in orders)
                    {
                        var mapping = mappings.First(a => a.Item1 == order.Id).Item2;
                        var detail = orderDetails.First(a => a.Item1 == mapping);
                        if (order.UpdateStaff(detail.Item2, detail.Item3))
                        {
                            _ecomDbContext.Orders.Update(order);
                        }
                    }
                });

            await _uow.SaveChangesAsync();
        }
    }
}
