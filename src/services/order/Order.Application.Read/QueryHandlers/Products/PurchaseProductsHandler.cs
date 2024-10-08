using Dapper;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Application.Models.Products;
using ECommerce.Shared.Constant;
using MediatR;
using Order.Application.Models.Products;
using Order.Application.Read.Queries.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Read.QueryHandlers.Products
{
    public class PurchaseProductsHandler : IRequestHandler<ListPurchaseProductsQuery, QueryResult<ProductPurchaseDto>>,
                                                IRequestHandler<TopPurchaseProductsQuery, QueryResult<ProductPurchaseDto>>
    {
        private readonly IDbConnection _dbConnection;

        public PurchaseProductsHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<QueryResult<ProductPurchaseDto>> Handle(ListPurchaseProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await GetPurchaseProduct(request.CustomerId, request.Skip, request.Take);
            return new QueryResult<ProductPurchaseDto>(result.count, result.items);
        }
        public async Task<QueryResult<ProductPurchaseDto>> Handle(TopPurchaseProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await GetPurchaseProduct(request.CustomerId, 0, await GetConfig(ConfigKeys.TopPurchaseProduct));
            return new QueryResult<ProductPurchaseDto>(result.count, result.items);
        }
        public async Task<(int count, IEnumerable<ProductPurchaseDto> items)> GetPurchaseProduct(Guid customerId, int skip, int take)
        {
            var orderProductIdsTemplate = new SqlBuilder().AddTemplate(
                @$" SELECT  ODD.product_id, ODD.order_id
                            FROM    ""order"".order_details ODD
                                    INNER JOIN(
                                        SELECT id FROM ""order"".orders WHERE customer_id = @CustomerId
                                    ) ORD
                                    ON ORD.id = ODD.order_id");

            var orderProductIds = await _dbConnection.QueryAsync<(Guid productId, Guid orderId)>(orderProductIdsTemplate.RawSql, new { CustomerId = customerId });
            orderProductIds = orderProductIds.Distinct();
            var groupProductIds = orderProductIds.GroupBy(r => r.productId).Select(r => new
            {
                Id = r.Key,
                Count = r.Count()
            });

            var request = new
            {
                Ids = groupProductIds.Select(r => r.Id).ToList(),
                Skip = skip,
                Take = take

            };
            var IdsDictionary = new Dictionary<Guid, int>();
            foreach (var item in groupProductIds)
            {
                IdsDictionary.Add(item.Id, item.Count);
            }

            var productPriceTemplate = new SqlBuilder().AddTemplate(@$" SELECT  product_id, price FROM product_prices WHERE product_id  = ANY (@Ids)");
            var productPriceBuilder = await _dbConnection.QueryAsync<(Guid productId, decimal price)>(productPriceTemplate.RawSql,
                                                                                    new { Ids = groupProductIds.Select(r => r.Id).ToList() });
            var productsPriceResult = productPriceBuilder.GroupBy(r => r.productId)
                                                            .Select(r => new
                                                            {
                                                                productId = r.Key,
                                                                priceMin = r.Min(r => r.price),
                                                                priceMax = r.Max(r => r.price)
                                                            }).ToList();
            var builder = new SqlBuilder();
            var countProductTemplate = builder.AddTemplate(@$"SELECT count(id) FROM products /**where**/ /**orderby**/;");
            var productTemplate = builder.AddTemplate(
                @$" SELECT id, name, image, images AS image_list, thumb_image, description
                    FROM    products
                    /**where**/ /**orderby**/ offset @Skip rows fetch next @Take row only;
                ");
            builder.Where("id = ANY(@Ids)", request);

            var productsResult = await _dbConnection.QueryMultipleAsync($"{countProductTemplate.RawSql} {productTemplate.RawSql}", request);

            var count = await productsResult.ReadFirstOrDefaultAsync<int>();
            var products = (await productsResult.ReadAsync<ProductPurchaseDto>()).ToList();

            products.ForEach(r =>
            {
                if (IdsDictionary.TryGetValue(r.Id, out var grpObject))
                    r.CountPurchaseProduct = grpObject;
                r.PriceMin = productsPriceResult.FirstOrDefault(r => r.productId == r.productId).priceMin;
                r.PriceMax = productsPriceResult.FirstOrDefault(r => r.productId == r.productId).priceMax;
            });

            return (count, products);
        }
        public async Task<int> GetConfig(string key)
        {
            var builder = new SqlBuilder();
            var configurationTemplate =
                builder.AddTemplate(@$"SELECT value FROM  system_configurations WHERE key = @Key;");
            var val = await _dbConnection.QueryFirstOrDefaultAsync<string>(configurationTemplate.RawSql, new { Key = key });
            return int.TryParse(val, out var inter) ? inter : 10;
        }
    }
}
