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
    public class SyncQuantityInStockJob : ISyncQuantityInStockJob
    {
        private readonly IEComDbConnection _ecomConn;
        private readonly ISaasDbConnection _saasConn;
        private readonly ISynchronizeUnitOfWork _uow;
        private readonly ECommerceDbContext _ecomDbContext;
        private readonly int BatchSize;

        public SyncQuantityInStockJob(IEComDbConnection ecomConn, ISaasDbConnection saasConn, ISynchronizeUnitOfWork uow, ECommerceDbContext ecomDbContext, IOptionsSnapshot<SynchronizeConfigurations> options)
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
                    var quantities = await _saasConn.QueryAsync<(uint, decimal)>(@"select _product.Id, _product_vendor_store.QuantityInstock from _product_vendor_store
                        join _product on _product.id = _product_vendor_store.ProductId
                        where !_product_vendor_store.IsDeleted and _product_vendor_store.IsActivated and _product.IsActivated and !_product.IsDeleted
                        and _product.Id in @Ids", new
                    {
                        Ids = mappings.Select(x => x.Item2).ToArray(),
                    });
                    var childrenIds = mappings.Where(a => quantities.Select(b => b.Item1).Contains(a.Item2)).Select(a => a.Item1);
                    var productChildren = await _ecomDbContext.ProductChildren.Where(a => childrenIds.Contains(a.Id)).ToListAsync();
                    foreach (var child in productChildren)
                    {
                        var mapping = mappings.First(a => a.Item1 == child.Id).Item2;
                        var quantity = Convert.ToUInt32(quantities.First(a => a.Item1 == mapping).Item2);
                        if (child.UpdateQuantityInStock(quantity))
                        {
                            _ecomDbContext.ProductChildren.Update(child);
                        }
                    }
                });

            await _uow.SaveChangesAsync();
        }
    }
}
