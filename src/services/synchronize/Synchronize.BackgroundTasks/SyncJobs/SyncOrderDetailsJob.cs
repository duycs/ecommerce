using Dapper;
using ECommerce.Shared.Extensions;
using ECommerce.Shared.Helpers.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scheduler.Jobs.CronJobs.SyncJobs;
using Synchronize.BackgroundTasks.Helpers;
using Synchronize.Domain.OrderAggregate;
using Synchronize.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synchronize.BackgroundTasks.SyncJobs
{
    public class SyncOrderDetailsJob : ISyncOrderDetailsJob
    {
        private readonly IEComDbConnection _ecomConn;
        private readonly ISaasDbConnection _saasConn;
        private readonly ISynchronizeUnitOfWork _uow;
        private readonly ECommerceDbContext _ecomDbContext;
        private readonly int BatchSize;

        public SyncOrderDetailsJob(IEComDbConnection ecomConn, ISaasDbConnection saasConn, ISynchronizeUnitOfWork uow, ECommerceDbContext ecomDbContext, IOptionsSnapshot<SynchronizeConfigurations> options)
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
                    foreach (var oldOrderId in mappings)
                    {
                        var orderDetails = await _saasConn.QueryAsync<(uint, decimal)>(@"select cod.ProductModelId, cod.Quantity from _customer_order co
                            join _customer_order_detail cod on co.Id = cod.CustomerOrderId
                            where co.StatusCode != 'cancel' and co.StatusCode != 'completed' and co.StatusCode != 'waiting_export'
                            and !co.IsDeleted and co.IsActivated and !cod.IsDeleted and co.Id = @Id", new
                        {
                            Id = oldOrderId.Item2,
                        });
                        if (orderDetails.IsNullOrEmpty())
                        {
                            continue;
                        }
                        var productChildMappings = await _ecomConn.QueryAsync<(Guid, uint)>(@"select product_child_id, old_id in integration.product_child_mappings where old_id = any(@Ids", new
                        {
                            Ids = orderDetails.Select(a => Convert.ToInt32(a.Item1)).ToArray()
                        });
                        var details = await _ecomDbContext.OrderDetails.Where(a => a.OrderId == oldOrderId.Item1).ToListAsync();

                        // Update quantity only
                        var updatedDetails = details.Where(a =>
                        {
                            var childMap = productChildMappings.First(b => b.Item1 == a.ProductChildId).Item2;
                            var quantity = Convert.ToUInt16(orderDetails.First(b => b.Item1 == childMap).Item2);
                            if (a.UpdateQuantity(quantity))
                            {
                                return true;
                            }
                            return false;
                        }).Select(a => a);
                        _ecomDbContext.UpdateRange(updatedDetails);

                        // New details
                        var newProductMappings = productChildMappings.Where(a => !details.Select(b => b.OrderId).Contains(a.Item1)).ToList();
                        if (newProductMappings.Any())
                        {
                            var childDetailsQuery = await _ecomConn.QueryMultipleAsync(@"select pc.id as product_child_id, pc.name as product_child_name, pc.sku as product_child_sku, pc.attribute_value_ids,
                                   b.id as brand_id, b.name as brand_name,
                                   p.id as product_id, p.name as product_name, p.sku as product_sku,
                                   c.id as product_category_id, c.name as product_category_name,
                                   s.id as shop_id, s.name as shop_name
                            from public.product_children pc
                            join public.products p on pc.product_id = p.id
                            left join public.brands b on p.brand_id = b.id
                            join public.product_categories c on p.category_id = c.id
                            join public.shops s on p.shop_id = s.id
                            where pc.id  = any(@ProductChildIds);
                            select product_child_id, price, price_discount, quantity_from, quantity_to, is_limit_quantity from public.product_prices where product_child_id = Any(@ProductChildIds);
                            select pav.id, pav.code, pav.name, pav.value, pa.name as attribute_name, pa.priority from public.product_attribute_values pav
                            join public.product_attributes pa on pav.attribute_id = pa.id
                            join public.product_children pc on pa.product_id = pc.product_id
                            where pc.id = Any(@ProductChildIds)
                            group by pav.id, pav.code, pav.name, pav.value, pa.name as attribute_name, pa.priority", new
                            {
                                ProductChildIds = newProductMappings.Select(a => a.Item1).ToArray(),
                            });

                            var childDetails = await childDetailsQuery.ReadAsync<ProductChildDetailDto>();
                            var childPrices = await childDetailsQuery.ReadAsync<ProductChildPriceDto>();
                            var childAttrValues = await childDetailsQuery.ReadAsync<OrderProductAttributeValue>();

                            foreach (var productMapping in newProductMappings)
                            {
                                var quantity = Convert.ToUInt32(orderDetails.First(a => a.Item1 == productMapping.Item2).Item2);
                                var productDetail = childDetails.First(a => a.ProductChildId == productMapping.Item1);
                                var price = childPrices.FirstOrDefault(a => a.ProductChildId == productMapping.Item1 && (!a.IsLimitQuantity || (a.QuantityTo <= quantity && a.QuantityFrom >= quantity)));
                                var orderDetail = new OrderDetail(oldOrderId.Item1, quantity, price?.Price ?? 0, price?.PriceDiscount ?? 0,
                                    productDetail.ProductId, productDetail.ProductSku, productDetail.ProductName,
                                    productDetail.ProductChildId, productDetail.ProductChildName, productDetail.ProductChildSku,
                                    productDetail.BrandId, productDetail.BrandName,
                                    productDetail.ProductCategoryId, productDetail.ProductCategoryName,
                                    productDetail.ShopId, productDetail.ShopName);
                                orderDetail.AddAttributeValues(childAttrValues.Where(a => productDetail.AttributeValueIds.Contains(a.Id)).ToList());

                                _ecomDbContext.OrderDetails.Add(orderDetail);
                            }
                        }

                        // delete details
                        var deletedProductMappings = details.Select(a => a.ProductChildId).Where(a => productChildMappings.All(b => b.Item1 != a)).ToList();
                        if (deletedProductMappings.Any())
                        {
                            var detailsForDelete = details.Where(a => deletedProductMappings.Contains(a.ProductChildId)).ToList();
                            _ecomDbContext.OrderDetails.RemoveRange(detailsForDelete);
                        }
                    }
                });

            await _uow.SaveChangesAsync();
        }
    }

    public class ProductChildDetailDto
    {
        public Guid OrderId { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public Guid ProductId { get; set; }
        public string ProductSku { get; set; }
        public string ProductName { get; set; }
        public Guid ProductChildId { get; set; }
        public string ProductChildName { get; set; }
        public string ProductChildSku { get; set; }
        public Guid? BrandId { get; set; }
        public string BrandName { get; set; }
        public Guid ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public IEnumerable<Guid> AttributeValueIds { get; set; }
    }

    public class ProductChildPriceDto
    {
        public Guid ProductChildId { get; set; }
        public decimal Price { get; set; }
        public decimal PriceDiscount { get; set; }
        public uint QuantityFrom { get; set; }
        public uint QuantityTo { get; set; }
        public bool IsLimitQuantity { get; set; }
    }
}
