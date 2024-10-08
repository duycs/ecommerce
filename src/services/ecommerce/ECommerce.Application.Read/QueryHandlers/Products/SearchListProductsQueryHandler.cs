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
    public class SearchListProductsQueryHandler : IRequestHandler<SearchListProductsQuery, QueryResult<SearchProductDto>>
    {
        private readonly IDbConnection _dbConnection;

        public SearchListProductsQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<QueryResult<SearchProductDto>> Handle(SearchListProductsQuery request, CancellationToken cancellationToken)
        {
            string tableProductType = "";
            var builder = new SqlBuilder();
            var productBuilder = new SqlBuilder();
            var productPriceBuilder = new SqlBuilder();

            #region tableProductType
            if (!string.IsNullOrEmpty(tableProductType))
            {
                if (request.ProductTypeId == ProductType.New.Id)
                    tableProductType = "new_products";
                else if (request.ProductTypeId == ProductType.BestSelling.Id)
                    tableProductType = "best_selling_products";
                else if (request.ProductTypeId == ProductType.Suggested.Id)
                    tableProductType = "suggest_products";
                else
                    throw new BusinessRuleException(ECommerceBusinessRule.TableNameInvalid);
            }
            #endregion

            var productTemplate = productBuilder.AddTemplate(@"SELECT id, created_date FROM products /**where**/");
            var productPriceTemplate =
                productPriceBuilder.AddTemplate(@"SELECT product_child_id, price  FROM  product_prices /**where**/");

            request.BrandIds = request.BrandIds?.Where(a => a.HasValue).ToList() ?? new List<Guid?>();
            if (request.BrandIds.Any())
                productBuilder.Where(@"brand_id = any(@BrandIds)");

            request.SubCategoryIds = request.SubCategoryIds?.Where(a => a.HasValue).ToList() ?? new List<Guid?>();
            if (request.SubCategoryIds.Any())
                productBuilder.Where(@"category_id = any(@SubCategoryIds)");
            else
            {
                if (request.ParentCategoryId.HasValue)
                {
                    var categoryBuilder = new SqlBuilder();
                    var categoryBuilderTemplate = categoryBuilder.AddTemplate($@"SELECT id FROM product_categories /**where**/;");
                    categoryBuilder.Where($@"parent_id = @ParentId");

                    IEnumerable<Guid> productCategoryIds = await _dbConnection.QueryAsync<Guid>($@"
                                                        {categoryBuilderTemplate.RawSql}",
                                                            new { ParentId = request.ParentCategoryId.Value });
                    if (productCategoryIds.Any())
                    {
                        foreach (var productCategoryId in productCategoryIds)
                        {
                            request.SubCategoryIds.Add(productCategoryId);
                        }
                        productBuilder.Where(@"category_id = any(@SubCategoryIds)");
                    }
                    else
                        return new QueryResult<SearchProductDto>();
                }
            }

            // todo: xe lai  SearchValue
            //if (!string.IsNullOrEmpty(request.SearchValue))
            //    productBuilder.Where(@"search_vector @@ to_tsquery(@SearchValue)");

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                productBuilder.OrWhere($@"unaccent(name) ilike @SearchQuery");
                productBuilder.OrWhere($@"sku  ilike @SearchQuery");
            }
            if (request.MinPrice > 0)
            {
                productPriceBuilder.Where(@"price >= @MinPrice");
            }

            if (request.MaxPrice > 0)
            {
                productPriceBuilder.Where(@"price <= @MaxPrice");
            }

            var countTemplate = builder.AddTemplate($@" 
                    select count(p1.id) from (
                        SELECT 
	                        p.id, sum(product_children.quantity_in_stock) AS  quantity_in_stock
                        FROM
                            ({productTemplate.RawSql})   p                       
                        /**innerjoin**/
                        /**groupby**/) p1 /**where**/ ;");

            var itemsTemplate = builder.AddTemplate($@" 
                        SELECT
                        id, min_price, max_price
                        FROM                        
                            (SELECT 
	                        p.id, min(pprices.price) as min_price, max(pprices.price) as max_price, sum(product_children.quantity_in_stock) AS  quantity_in_stock
                        FROM
                            ({productTemplate.RawSql})   p                       
                        /**innerjoin**/
                        /**groupby**/) p1 /**where**/ offset @Skip rows fetch next @Take rows only;");

            builder.InnerJoin(@"product_children  on p.id = product_children.product_id ");
            builder.InnerJoin($@"({productPriceTemplate.RawSql})  pprices ON product_children.id = pprices.product_child_id");

            if (request.QuantityStatus == ConfigStatus.ProductQuantityStatus.Stocking)
                builder.Where("@quantity_in_stock > 0");
            else if (request.QuantityStatus == ConfigStatus.ProductQuantityStatus.OutStock)
                builder.Where(@"quantity_in_stock = 0");

            builder.GroupBy("p.id");

            if (!string.IsNullOrEmpty(tableProductType))
                builder.InnerJoin($@"{tableProductType} p_type on p.id = p_type.product_id");

            var dataResult = await _dbConnection.QueryMultipleAsync($@"{countTemplate.RawSql}{itemsTemplate.RawSql}", request);

            var count = dataResult.ReadFirst<int>();
            IEnumerable<SearchProductResultDto> productsSearch = dataResult.Read<SearchProductResultDto>();

            //2 : Thong tin danh sach san pham
            List<Guid> productsSearchIds = productsSearch.Select(s => s.Id).ToList();

            var inforProductBuilder = new SqlBuilder();

            var inforProductsTemplate = inforProductBuilder.AddTemplate(@"
                                SELECT 
                                    id, sku, name ,  brand_id , category_id ,
                                    description , image, thumb_image ,  images , is_sell_full_size 
                              FROM products WHERE id = ANY(@Ids);");

            // 3. Lay gia theo san pham
            var productsPriceTemplate =
                              inforProductBuilder.AddTemplate(@"
                               SELECT 
                                    pchild_group.product_id, sum(pchild_group.quantity_in_stock) AS total_quantity_in_stock, min(pchild_group.min_price) AS min_price, max(pchild_group.max_price) AS max_price
                               FROM 
                                      (SELECT pchild.id, pchild.product_id, min(pchild.quantity_in_stock) AS quantity_in_stock, min(pprice.price) AS min_price, max(pprice.price) AS max_price 
                                      FROM 
                                           (SELECT id, product_id, quantity_in_stock from product_children WHERE product_id = ANY(@ProductId)) pchild
                                       LEFT JOIN product_prices AS pprice 
                                       ON  pchild.id = pprice.product_child_id   
                                       GROUP BY pchild.id, pchild.product_id) AS pchild_group 
                               GROUP BY  pchild_group.product_id;");

            var resultInforProduct = await _dbConnection.QueryMultipleAsync($@"
                            {inforProductsTemplate.RawSql}           
                            {productsPriceTemplate.RawSql}",
                            new
                            {
                                Ids = productsSearchIds,
                                ProductId = productsSearchIds
                            });

            IEnumerable<ProductDto> products = resultInforProduct.Read<ProductDto>();

            IEnumerable<ProductMinMaxPriceDto> productsPrice = resultInforProduct.Read<ProductMinMaxPriceDto>();

            var dataProductResult = from ps in productsSearch
                                    join p in products on ps.Id equals p.Id
                                    join pPrice in productsPrice on p.Id equals pPrice.ProductId
                                    select new SearchProductDto
                                    {
                                        Id = p.Id,
                                        Description = p.Description,
                                        Image = p.Image,
                                        Images = p.Images,
                                        Name = p.Name,
                                        PriceMax = pPrice.MaxPrice,
                                        PriceMin = pPrice.MinPrice,
                                        Sku = p.Sku,
                                        IsSellFullSize = p.IsSellFullSize,
                                        BrandId = p.BrandId,
                                        CategoryId = p.CategoryId,
                                        TotalQuantityInStock = pPrice.TotalQuantityInStock
                                    };

            return new QueryResult<SearchProductDto>(count, dataProductResult); ;
        }

        private class SearchProductResultDto
        {
            public Guid Id { get; set; }
            public decimal MinPrice { get; set; }
            public decimal MaxPrice { get; set; }
        }


    }
}
