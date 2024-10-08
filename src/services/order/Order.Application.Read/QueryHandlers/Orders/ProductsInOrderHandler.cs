using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR; 
using Order.Application.Models.Orders;
using Order.Application.Models.ProductAttributes;
using Order.Application.Read.Queries.Orders;

namespace Order.Application.Read.QueryHandlers.Orders
{
    public class ProductsInOrderHandler : IRequestHandler<ProductsInOrderQuery, QueryResult<ProductInOrderDto>>
    {
        private readonly IDbConnection _dbConnection;

        public ProductsInOrderHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<QueryResult<ProductInOrderDto>> Handle(ProductsInOrderQuery request, CancellationToken cancellationToken)
        {

            var builder = new SqlBuilder();

            var tmpOrderDetail = builder.AddTemplate(@$"
                    SELECT  ODD.product_id as id, ODD.product_sku, ODD.product_image,
                            ODD.quantity AS total_quantity, ODD.product_name AS name, ODD.price,
                            (attribute_values ::json-> 0) ::json ->'name' AS name1,(attribute_values ::json-> 0) ::json ->'priority' AS priority1,
                            (attribute_values ::json -> 1) ::json ->'name' AS name2,(attribute_values ::json-> 1) ::json ->'priority' AS priority2
                    FROM    ""order"".order_details ODD
                            INNER JOIN(
                                SELECT  id
                                FROM    ""order"".orders
                                WHERE   id = @id
                                        AND  customer_id = @customerId
                            ) ORD
                            ON  ODD.order_id = ORD.id");



            var resultRaw = await _dbConnection.QueryAsync<ProductInOrderDto>(tmpOrderDetail.RawSql, request);
            resultRaw.ToList().ForEach(r => r.SetDefaultColor());

            var result = resultRaw.GroupBy(r => new
            {
                r.Id,
                r.ProductSku,
                r.ProductImage,
                r.Name,
                r.Name1,
                r.Price
            }).Select(r => new ProductInOrderDto
            {
                Id = r.Key.Id,
                ProductSku = r.Key.ProductSku,
                ProductImage = r.Key.ProductImage,
                Name = r.Key.Name,
                TotalQuantity = r.Sum(r => r.TotalQuantity),
                Price = r.Key.Price,
                AttributeColorName = r.Key.Name1?.Replace("\"", "").Trim(),
                AttributeValuesList = r.Select(ra => new ProductAttributeOrder
                {
                    Code = ra.Name2?.Replace("\"", "").Trim(),
                    TotalQuantity = ra.TotalQuantity
                })
            });

            return new QueryResult<ProductInOrderDto>(0, result);
        }
    }
}
