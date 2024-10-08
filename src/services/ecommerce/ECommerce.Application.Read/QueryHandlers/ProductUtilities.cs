using Dapper;
using ECommerce.Application.Models.Products;
using ECommerce.Application.ServiceInterfaces.HandlerInterface;
using ECommerce.Domain.Enums;
using ECommerce.Shared.Constant;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers
{
    public class ProductUtilities : IProductUtilities
    {
        private readonly IDbConnection _dbConnection;

        public ProductUtilities(IDbConnection dbconnection)
        {
            _dbConnection = dbconnection;
        }

        public async Task<int> GetConfig(string key)
        {
            var builder = new SqlBuilder();
            var configurationTemplate =
                builder.AddTemplate(@$"SELECT value FROM  system_configurations WHERE key = @Key;");
            var val = await _dbConnection.QueryFirstOrDefaultAsync<string>(configurationTemplate.RawSql, new { Key = key });
            return int.TryParse(val, out var inter) ? inter : 10;
        }

        public async Task<IEnumerable<TopProductDto>> GetTopProduct(int producttypeId, int top)
        {
            string tableName = "";

            if (producttypeId == ProductType.New.Id)
                tableName = ConfigKeys.NewProductTableName;
            else if (producttypeId == ProductType.BestSelling.Id)
                tableName = ConfigKeys.BestSellingProductTableName;
            else if (producttypeId == ProductType.Suggested.Id)
                tableName = ConfigKeys.SuggestProductTableName;

            var builder = new SqlBuilder();

            var topProductTypeTemplate = builder.AddTemplate($@"
                                        SELECT  /**select**/ FROM {tableName} as product_type
                                        /**innerjoin**/
                                        /**where**/
                                        /**groupby**/
                                        /**orderby**/
                                        offset 0 rows fetch next @Top rows only;");
            builder.InnerJoin(@"products on product_type.product_id = products.id");
            builder.InnerJoin(@"product_children on products.id = product_children.product_id");
            builder.Where(@"product_children.quantity_in_stock > 0");
            builder.GroupBy("products.id");
            builder.OrderBy("priority ASC");
            builder.Select(@"products.id AS product_id, 
                            sum(product_children.quantity_in_stock) AS total_quantity_in_stock,
                            min(product_type.priority) AS priority ");

            var topProductType = await _dbConnection.QueryAsync<ProductTypeDto>($@"{topProductTypeTemplate.RawSql}", new { Top = top });

            if (!topProductType.Any())
            {
                return new List<TopProductDto>();
            }

            //2 : Thong tin danh sach san pham
            List<Guid> topProductIds = topProductType.Select(s => s.ProductId).ToList();

            var inforProductBuilder = new SqlBuilder();

            var inforProductsTemplate = inforProductBuilder.AddTemplate($@"
                                SELECT 
                                    id, name, sku, image, images, description, is_sell_full_size , @ProductType as product_type_id
                              FROM products WHERE id = ANY(@Ids);");
            // 3.Lay gia theo san pham
            var inforProductChildrenTemplate =
                                inforProductBuilder.AddTemplate($@"
                                 SELECT 
                                    pchild.product_id, min(pprice.price) as min_price, max(pprice.price) as max_price
                                 FROM 
                                     (SELECT product_children.id, product_children.product_id FROM product_children  WHERE product_id = ANY(@ProductIds)) pchild
                                 LEFT JOIN product_prices AS pprice 
                                 ON  pchild.id = pprice.product_child_id
                                GROUP BY pchild.product_id;");

            var resultInforProduct = await _dbConnection
                        .QueryMultipleAsync($@"
                            {inforProductsTemplate.RawSql}            
                            {inforProductChildrenTemplate.RawSql}",
                            new
                            {
                                Ids = topProductIds,
                                ProductType = producttypeId,
                                ProductIds = topProductIds
                            });

            IEnumerable<ProductDto> products = resultInforProduct.Read<ProductDto>();

            IEnumerable<ProductMinMaxPriceDto> groupProducChildrenPrice = resultInforProduct.Read<ProductMinMaxPriceDto>();

            var dataResult = from ptype in topProductType
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
            return dataResult;
        }


    }
}
