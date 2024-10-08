using Dapper;
using ECommerce.Application.Models.Carts;
using ECommerce.Application.Models.Products;
using ECommerce.Application.Read.Queries.Carts;
using ECommerce.Domain.AggregateModels.CartAggregate;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce.Application.Read.QueryHandlers.Carts
{
    public class DetailsQueryHandler : IRequestHandler<DetailsQuery, IEnumerable<AttributeValueDto>>
    {
        private readonly IDbConnection _dbConnection;

        public DetailsQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<AttributeValueDto>> Handle(DetailsQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"select product_child.*, pav.name as attribute_value_name, pav.value as attribute_value, pa.name as attribute_name, pa.priority from (
                    select product_children.id, 
                    cart_details.quantity as quantity_order, 
                    product_children.product_id, 
                    product_children.quantity_in_stock, 
                    products.name as product_name, 
                    products.sku,
                    products.image as product_image,
                    products.is_sell_full_size as product_is_sell_full_size,
                    brands.name as brand_name, 
                    pp.price,
                    product_children.attribute_value_ids,
                    unnest(product_children.attribute_value_ids) as attribute_value_id from carts
                join cart_details on carts.id = cart_details.cart_id
                join product_children on cart_details.product_child_id = product_children.id
                join products on product_children.product_id = products.id
                join product_prices pp on pp.product_child_id = product_children.id 
                left join brands on products.brand_id = brands.id /**where**/) product_child
            join product_attribute_values pav on pav.id = product_child.attribute_value_id
            join product_attributes pa on pav.attribute_id = pa.id");
            builder.Where(@"carts.customer_id = @CustomerId");
            var attributeValueChildren = await _dbConnection.QueryAsync<AttributeValueChildDto>(template.RawSql, request);
            var result = attributeValueChildren.Where(a => a.Priority == 1).GroupBy(a => a.AttributeValueId, b => b, (a, b) =>
            new
            {
                Id = a,
                Value = b.FirstOrDefault()
            }).Select(a =>
            {
                return new AttributeValueDto()
                {
                    AttributeName = a.Value.AttributeName,
                    AttributeValue = a.Value.AttributeValue,
                    ProductId = a.Value.ProductId,
                    ProductName = a.Value.ProductName,
                    BrandName = a.Value.BrandName,
                    AttributeValueName = a.Value.AttributeValueName,
                    ProductImage = a.Value.ProductImage,
                    ProductIsSellFullSize = a.Value.ProductIsSellFullSize,
                    Sku = a.Value.Sku,
                    Children = attributeValueChildren.Where(b => b.ProductId == a.Value.ProductId && b.AttributeValueIds.Contains(a.Id) && b.Priority != 1)
                };
            });
            return result;
        }

        public class AttributeValueCartDto
        {
            public Guid ProductId { get; set; }
            public Guid AttributeId { get; set; }
            public string AttributeName { get; set; }
            public int AttributePriority { get; set; }
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
