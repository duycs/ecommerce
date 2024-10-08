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
    public class SyncDeletedProductJob : ISyncDeletedProductJob
    {
        private readonly IEComDbConnection _ecomConn;
        private readonly ISaasDbConnection _saasConn;
        private readonly ISynchronizeUnitOfWork _uow;
        private readonly ECommerceDbContext _ecomDbContext;
        private readonly int BatchSize;

        public SyncDeletedProductJob(IEComDbConnection ecomConn, ISaasDbConnection saasConn, ISynchronizeUnitOfWork uow, ECommerceDbContext ecomDbContext, IOptionsSnapshot<SynchronizeConfigurations> options)
        {
            _ecomConn = ecomConn;
            _saasConn = saasConn;
            _uow = uow;
            _ecomDbContext = ecomDbContext;
            BatchSize = options.Value?.BatchSize ?? 1000;
        }

        public async Task Run()
        {
            await DeleteChildrenProduct();
            await DeleteProducts();
            await _uow.SaveChangesAsync();
        }

        private async Task DeleteChildrenProduct()
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
                    var products = await _saasConn.QueryAsync<uint>(@"select Id from _product where (IsDeleted or !IsActivated) and Id in @Ids", new
                    {
                        Ids = mappings.Select(x => x.Item2).ToArray(),
                    });
                    var childrenIds = mappings.Where(a => products.Contains(a.Item2)).Select(a => a.Item1);
                    var productChildren = await _ecomDbContext.ProductChildren.Where(a => childrenIds.Contains(a.Id)).ToListAsync();
                    if (!productChildren.IsNullOrEmpty())
                    {
                        _ecomDbContext.ProductChildren.RemoveRange(productChildren);
                        var maps = await _ecomDbContext.ChildProductMappings.Where(a => productChildren.Select(b => b.Id).Contains(a.ChildProductId)).ToListAsync();
                        _ecomDbContext.ChildProductMappings.RemoveRange(maps);
                    }
                });
        }

        private async Task DeleteProducts()
        {
            await AsyncIterator<(Guid, uint)>
                .From(async (skip, take) => await _ecomConn.QueryAsync<(Guid, uint)>(@"select product_id, old_id from integration.product_mappings order by old_id offset @Skip rows fetch next @Take rows only", new
                {
                    Skip = skip,
                    Take = take
                }))
                .WithChunkSize(1000)
                .ForChunk(async mappings =>
                {
                    var products = await _saasConn.QueryAsync<uint>(@"select Id from _product where (IsDeleted or !IsActivated) and Id in @Ids", new
                    {
                        Ids = mappings.Select(x => x.Item2).ToArray(),
                    });
                    var childrenIds = mappings.Where(a => products.Contains(a.Item2)).Select(a => a.Item1);
                    var productChildren = await _ecomDbContext.Products.Where(a => childrenIds.Contains(a.Id)).ToListAsync();
                    if (!productChildren.IsNullOrEmpty())
                    {
                        _ecomDbContext.Products.RemoveRange(productChildren);
                        var maps = await _ecomDbContext.ProductMappings.Where(a => productChildren.Select(b => b.Id).Contains(a.ProductId)).ToListAsync();
                        _ecomDbContext.ProductMappings.RemoveRange(maps);
                    }
                });
        }
    }
}
