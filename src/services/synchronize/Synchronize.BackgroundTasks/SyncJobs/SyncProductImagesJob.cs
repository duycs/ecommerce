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
    public class SyncProductImagesJob : ISyncProductImagesJob
    {
        private readonly IEComDbConnection _ecomConn;
        private readonly ISaasDbConnection _saasConn;
        private readonly ISynchronizeUnitOfWork _uow;
        private readonly ECommerceDbContext _ecomDbContext;
        private readonly int BatchSize;

        public SyncProductImagesJob(IEComDbConnection ecomConn, ISaasDbConnection saasConn, ISynchronizeUnitOfWork uow, ECommerceDbContext ecomDbContext, IOptionsSnapshot<SynchronizeConfigurations> options)
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
                .From(async (skip, take) => await _ecomConn.QueryAsync<(Guid, uint)>(@"select product_id, old_id from integration.product_mappings order by old_id offset @Skip rows fetch next @Take rows only", new
                {
                    Skip = skip,
                    Take = take
                }))
                .WithChunkSize(BatchSize)
                .ForChunk(async mappings =>
                {
                    var images = await _saasConn.QueryAsync<(uint, string)>(@"select Id, Images from _product
                        where !IsDeleted and IsActivated and _product.Id in @Ids", new
                    {
                        Ids = mappings.Select(x => x.Item2).ToArray(),
                    });
                    var productIds = mappings.Where(a => images.Select(b => b.Item1).Contains(a.Item2)).Select(a => a.Item1);
                    var products = await _ecomDbContext.Products.Where(a => productIds.Contains(a.Id)).ToListAsync();
                    foreach (var product in products)
                    {
                        var mapping = mappings.First(a => a.Item1 == product.Id).Item2;
                        var image = images.First(a => a.Item1 == mapping).Item2;
                        if (product.UpdateImages(image))
                        {
                            _ecomDbContext.Products.Update(product);
                        }
                    }
                });

            await _uow.SaveChangesAsync();
        }
    }
}
