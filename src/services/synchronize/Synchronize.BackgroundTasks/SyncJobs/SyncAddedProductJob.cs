using Dapper;
using Scheduler.Jobs.CronJobs.SyncJobs;
using Synchronize.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaasModels = Synchronize.Domain.SaasAggregate;
using EComModels = Synchronize.Domain.EComAggregate;
using Synchronize.Domain.IntegrationAggregate;
using System.Linq;
using ECommerce.Shared.Helpers.Utils;

namespace Synchronize.BackgroundTasks.SyncJobs
{
    public class SyncAddedProductJob : ISyncAddedProductJob
    {
        private readonly IEComDbConnection _ecomConn;
        private readonly ISaasDbConnection _saasConn;
        private readonly ISynchronizeUnitOfWork _uow;
        private readonly ECommerceDbContext _ecomDbContext;

        public SyncAddedProductJob(IEComDbConnection ecomConn, ISaasDbConnection saasConn, ISynchronizeUnitOfWork uow, ECommerceDbContext ecomDbContext)
        {
            _ecomConn = ecomConn;
            _saasConn = saasConn;
            _uow = uow;
            _ecomDbContext = ecomDbContext;
        }

        public async Task Run()
        {
            var shopId = await _ecomConn.QueryFirstAsync<Guid>(@"select id from public.shops where code = 'Saas' limit 1");
            await AsyncIterator<(uint, Guid)>
                .From(async (skip, take) => await _ecomConn.QueryAsync<(uint, Guid)>(@"select old_id, category_id from integration.category_mappings order by old_id offset @Skip rows fetch next @Take rows only", new
                {
                    Skip = skip,
                    Take = take
                }))
                .WithChunkSize(1)
                .ForEach(async mapping =>
                {
                    var productIds = await _saasConn.QueryAsync<uint>(@"select Id from _product where !IsDeleted and IsActivated and IsMigrationItem and CategoryId = @CategoryId", new
                    {
                        CategoryId = mapping.Item1,
                    });
                    var newProductIds = await _ecomConn.QueryAsync<uint>(@"select * from unnest(@ProductIds) except select old_id from integration.product_mappings", new
                    {
                        ProductIds = productIds.Select(a => Convert.ToInt32(a)).ToArray()
                    });
                    foreach (var newProductId in newProductIds)
                    {
                        var product = await _saasConn.QueryFirstAsync<SaasModels.Product>(@"select Id, BrandId, CategoryId, Name, Sku, Images, ParentId, Description, AttributeFixedId, AttributeInputId from _product where Id = @Id", new
                        {
                            Id = newProductId,
                        });
                        var brandId = await _ecomConn.QueryFirstOrDefaultAsync<Guid?>("select brand_id from integration.brand_mappings where old_id = @Id limit 1", new
                        {
                            Id = product.BrandId
                        });
                        var newProduct = new EComModels.Product(shopId, product.Sku, product.Name, product.Description, brandId, mapping.Item2, product.JsonImages?.Urls ?? Array.Empty<string>());

                        // Add mapping
                        _ecomDbContext.ProductMappings.Add(new ProductMapping(newProduct.Id, product.Id));
                        var children = await _saasConn.QueryAsync<SaasModels.Product>(@"select Id, BrandId, CategoryId, Name, Sku, Images, ParentId, Description, AttributeFixedId, AttributeInputId from _product where !IsDeleted and ParentId = @Id", new
                        {
                            Id = product.Id,
                        });
                        var attributeIds = children.Select(a => a.AttributeFixedId).ToList()
                        .Concat(children.Select(a => a.AttributeInputId))
                        .Where(a => a != null)
                        .Distinct()
                        .Select(a => (uint)a)
                        .ToList();

                        var attributes = await _saasConn.QueryAsync<SaasModels.ProductAttribute>(@"select Id, Code, Value, Label, TypeCode from _product_attribute where !IsDeleted and Id in @Ids", new
                        {
                            Ids = attributeIds
                        });
                        var attributeMapping = new Dictionary<uint, Guid>();
                        foreach (var attribute in attributes.GroupBy(a => a.TypeCode, a => a, (a, b) => new { Key = a, Values = b }))
                        {
                            var newAtt = new EComModels.ProductAttribute(string.IsNullOrEmpty(attribute.Key) ? string.Empty : attribute.Key,
                                newProduct.Id,
                                children.Any(a => attribute.Values.Any(b => b.Id == a.AttributeFixedId)) ? 1 : 2);

                            foreach (var item in attribute.Values)
                            {
                                var newAttValue = new EComModels.ProductAttributeValue(item.Code ?? string.Empty,
                                    item.Label ?? string.Empty,
                                    item.Value ?? string.Empty);

                                newAtt.AddValue(newAttValue);
                                attributeMapping.Add(item.Id, newAttValue.Id);

                                // Add mappings
                                _ecomDbContext.AttributeMappings.Add(new AttributeMapping(newAttValue.Id, item.Id));
                            }

                            _ecomDbContext.ProductAttributes.Add(newAtt);
                        }

                        foreach (var child in children)
                        {
                            var productChild = new EComModels.ProductChild(child.Sku, child.Name);
                            attributeMapping.TryGetValue((uint)child.AttributeFixedId, out var fixAtt);
                            attributeMapping.TryGetValue((uint)child.AttributeInputId, out var inputAtt);
                            var attributeValueIds = new Guid[] { };
                            if (fixAtt != Guid.Empty)
                            {
                                attributeValueIds = attributeValueIds.Append(fixAtt).ToArray();
                            }
                            if (inputAtt != Guid.Empty)
                            {
                                attributeValueIds = attributeValueIds.Append(inputAtt).ToArray();
                            }
                            productChild.SetAttributeValues(attributeValueIds);

                            var price = new EComModels.ProductPrice(productChild.Id, newProduct.Id, child.PriceWholesale.HasValue ? child.PriceWholesale.Value : 0);
                            productChild.AddPrice(price);

                            var stock = await _saasConn.QueryFirstOrDefaultAsync<decimal>("select QuantityInstock from _product_vendor_store where !IsDeleted and ProductId = @Id", new
                            {
                                Id = child.Id
                            });
                            productChild.UpdateQuantityInStock(Convert.ToUInt32(stock));
                            newProduct.AddChild(productChild);

                            // Add mappings
                            _ecomDbContext.ChildProductMappings.Add(new ChildProductMapping(productChild.Id, child.Id));
                        }

                        _ecomDbContext.Products.Add(newProduct);
                    }
                });

            await _uow.SaveChangesAsync();
        }
    }
}
