using Dapper;
using ECommerce.Application.Models.Products;
using ECommerce.Application.Read.Queries.Products;
using ECommerce.Domain.Enums;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet.Repositories;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.Products
{
    public class ListProductsTypeHandler : IRequestHandler<ListProductsTypeQuery, QueryResult<TopProductDto>>
    {
        private readonly IDbConnection _dbConnection;

        public ListProductsTypeHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<QueryResult<TopProductDto>> Handle(ListProductsTypeQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            if (request.ProductNameTable != ConfigKeys.NewProductTableName
                && request.ProductNameTable != ConfigKeys.BestSellingProductTableName
                && request.ProductNameTable != ConfigKeys.SuggestProductTableName)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.TableNameInvalid);
            } 
            var countProductTypeTemplate = builder.AddTemplate($@"
                                        SELECT count(product_id) FROM 
                                        ( SELECT products.id as product_id FROM {request.ProductNameTable} as product_type
                                        /**innerjoin**/
                                        /**where**/
                                        /**groupby**/) AS table_result;");

            var topProductsTypeTemplate = builder.AddTemplate($@"
                                        SELECT  /**select**/ FROM {request.ProductNameTable} as product_type
                                        /**innerjoin**/
                                        /**where**/
                                        /**groupby**/
                                        /**orderby**/
                                        offset @Skip rows fetch next @Take rows only;");
            builder.InnerJoin(@"products on product_type.product_id = products.id");
            builder.InnerJoin(@"product_children on products.id = product_children.product_id");
            builder.Where(@"product_children.quantity_in_stock > 0");
            builder.GroupBy("products.id");
            builder.OrderBy("priority ASC");
            builder.Select(@"products.id AS product_id, 
                            sum(product_children.quantity_in_stock) AS total_quantity_in_stock,
                            min(product_type.priority) AS priority ");

            var newProductBuilder = await _dbConnection.QueryMultipleAsync($@"{countProductTypeTemplate.RawSql}
                                                                              {topProductsTypeTemplate.RawSql}", request);

            int countProductType = newProductBuilder.ReadFirst<int>();
            var productsType = newProductBuilder.Read<ProductTypeDto>();


            if (!productsType.Any())
            {
                return new QueryResult<TopProductDto>();
            }

            //2 : Thong tin danh sach san pham
            List<Guid> topNewProductIds = productsType.Select(s => s.ProductId).ToList();

            var inforProductBuilder = new SqlBuilder();

            var inforProductsTemplate = inforProductBuilder.AddTemplate(@"
                                SELECT 
                                    id, name, sku, image, images, description, is_sell_full_size, @ProductType as product_type_id
                              FROM products WHERE id = ANY(@Ids);");

            // 3. Lay gia theo san pham
            var inforProductChildrenTemplate =
                                inforProductBuilder.AddTemplate(@"
                                 SELECT
                                    pchild.product_id, min(pprice.price) as min_price, max(pprice.price) as max_price
                                FROM 
                                     (SELECT id, product_id from product_children  WHERE product_id = ANY(@ProductId)) pchild
                                 LEFT JOIN product_prices AS pprice 
                                 ON  pchild.id = pprice.product_child_id
                                GROUP BY pchild.product_id;");

            int productTypeId = ProductTypeTable(request.ProductNameTable);
            var resultInforProduct = await _dbConnection
                                    .QueryMultipleAsync($@"
                                    {inforProductsTemplate.RawSql}           
                                    {inforProductChildrenTemplate.RawSql}",
                                    new
                                    {
                                        Ids = topNewProductIds,
                                        ProductType = productTypeId,
                                        ProductId = topNewProductIds
                                    });

            IEnumerable<ProductDto> products = resultInforProduct.Read<ProductDto>();

            IEnumerable<ProductMinMaxPriceDto> groupProducChildrenPrice = resultInforProduct.Read<ProductMinMaxPriceDto>();

            var dataResult = from ptype in productsType
                             join p in products on ptype.ProductId equals p.Id
                             join gChild in groupProducChildrenPrice on p.Id equals gChild.ProductId
                             select new TopProductDto
                             {
                                 Id = p.Id,
                                 Description = p.Description,
                                 Image = p.Image,
                                 Images = p.Images,
                                 Name = p.Name,
                                 PriceMax = gChild.MaxPrice,
                                 PriceMin = gChild.MinPrice,
                                 Priority = ptype.Priority,
                                 ProductType = p.ProductTypeId,
                                 Sku = p.Sku,
                                 IsSellFullSize = p.IsSellFullSize,
                                 TotalQuantityInStock = ptype.TotalQuantityInStock
                             };

            var count = countProductType;
            var items = dataResult;

            return new QueryResult<TopProductDto>(count, items);
        }
        private int ProductTypeTable(string nameTable)
        {
            int productTypeId = 0;
            if (nameTable == ConfigKeys.NewProductTableName)
                productTypeId = ProductType.New.Id;
            else if (nameTable == ConfigKeys.BestSellingProductTableName)
                productTypeId = ProductType.BestSelling.Id;
            else if (nameTable == ConfigKeys.SuggestProductTableName)
                productTypeId = ProductType.Suggested.Id;

            return productTypeId;
        }

    }
}
