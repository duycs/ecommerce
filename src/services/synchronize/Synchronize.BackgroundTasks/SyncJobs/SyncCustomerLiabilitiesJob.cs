using Dapper;
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
    public class SyncCustomerLiabilitiesJob : ISyncCustomerLiabilitiesJob
    {
        private readonly IEComDbConnection _ecomConn;
        private readonly ISaasDbConnection _saasConn;
        private readonly ISynchronizeUnitOfWork _uow;
        private readonly ECommerceDbContext _ecomDbContext;
        private readonly int BatchSize;

        public SyncCustomerLiabilitiesJob(IEComDbConnection ecomConn, ISaasDbConnection saasConn, ISynchronizeUnitOfWork uow, ECommerceDbContext ecomDbContext, IOptionsSnapshot<SynchronizeConfigurations> options)
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
                .From(async (skip, take) => await _ecomConn.QueryAsync<(Guid, uint)>("select customer_id, old_id from integration.customer_mappings order by old_id offset @Skip rows fetch next @Take rows only", new
                {
                    Skip = skip,
                    Take = take
                }))
                .WithChunkSize(BatchSize)
                .ForChunk(async mappings =>
                {
                    var liabilities = await _saasConn.QueryAsync<(uint, decimal, decimal)>("select Id, Liabilities, MaxLiabilities from _customer where !IsDeleted and IsActivated and Id in @Ids", new
                    {
                        Ids = mappings.Select(a => a.Item2).ToArray(),
                    });
                    var customerIds = mappings.Where(a => liabilities.Select(b => b.Item1).Contains(a.Item2)).Select(a => a.Item1);
                    var customers = await _ecomDbContext.Customers.Where(a => customerIds.Contains(a.Id)).ToListAsync();
                    foreach (var customer in customers)
                    {
                        var mapping = mappings.First(a => a.Item1 == customer.Id).Item2;
                        var liability = liabilities.First(a => a.Item1 == mapping);
                        if (customer.UpdateLiabilities(liability.Item2, liability.Item3))
                        {
                            _ecomDbContext.Customers.Update(customer);
                        }
                    }
                });

            await _uow.SaveChangesAsync();
        }
    }
}
