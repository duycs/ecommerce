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
    public class SyncPriceJob : ISyncPriceJob
    {
        private readonly IEComDbConnection _ecomConn;
        private readonly ISaasDbConnection _saasConn;
        private readonly ISynchronizeUnitOfWork _uow;
        private readonly ECommerceDbContext _ecomDbContext;
        private readonly int BatchSize;

        public SyncPriceJob(IEComDbConnection ecomConn, ISaasDbConnection saasConn, ISynchronizeUnitOfWork uow, ECommerceDbContext ecomDbContext, IOptionsSnapshot<SynchronizeConfigurations> options)
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
                .From(async (skip, take) => await _ecomConn.QueryAsync<(Guid, uint)>(@"select child_product_id, old_id from integration.child_product_mappings order by old_id offset @Skip rows fetch next @Take rows only", new
                {
                    Skip = skip,
                    Take = take
                }))
                .WithChunkSize(BatchSize)
                .ForChunk(async mappings =>
                {
                    var quantities = await _saasConn.QueryAsync<(uint, decimal)>(@"select Id, PriceWholesale from _product where !IsDeleted and IsActivated and Id in @Ids", new
                    {
                        Ids = mappings.Select(x => x.Item2).ToArray(),
                    });
                    var childrenIds = mappings.Where(a => quantities.Select(b => b.Item1).Contains(a.Item2)).Select(a => a.Item1);
                    var productChildren = await _ecomDbContext.ProductPrices.Where(a => childrenIds.Contains(a.ProductChildId) && !a.IsLimitQuantity).ToListAsync();
                    foreach (var child in productChildren)
                    {
                        var mapping = mappings.First(a => a.Item1 == child.ProductChildId).Item2;
                        var price = quantities.First(a => a.Item1 == mapping).Item2;
                        if (child.UpdatePrice(price))
                        {
                            _ecomDbContext.ProductPrices.Update(child);
                        }
                    }
                });

            await _uow.SaveChangesAsync();
        }
    }
}
