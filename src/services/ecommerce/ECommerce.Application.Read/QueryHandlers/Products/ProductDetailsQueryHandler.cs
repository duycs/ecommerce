using Dapper;
using ECommerce.Application.Models.Products;
using ECommerce.Application.Read.Queries.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Read.QueryHandlers.Products
{
    public class ProductDetailsQueryHandler : IRequestHandler<ProductDetailsQuery, ProductDetailsDto>
    {
        private readonly IDbConnection _dbConnection;

        public ProductDetailsQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ProductDetailsDto> Handle(ProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"select id, quantity_in_stock as quantity, sku, name, attribute_value_ids from product_children /**where**/;
                select pa.*, pav.id, pav.name, pav.value, pav.priority from (select id, name, priority from product_attributes /**where**/) pa
                join product_attribute_values pav on pav.attribute_id = pa.id");
            var productTemplate = new SqlBuilder().AddTemplate(@"select products.id, products.sku, products.name, brands.name as brand_name, product_categories.name as category_name, products.description, products.content, products.image, products.thumb_image, products.images, products.is_sell_full_size
                from products left join brands on products.brand_id = brands.id
                join product_categories on products.category_id = product_categories.id
                where products.id = @ProductId limit 1");
            var inCartTemplate = new SqlBuilder().AddTemplate(@"select cart_details.product_child_id, product_children.attribute_value_ids, cart_details.quantity from carts
                join cart_details on carts.id = cart_details.cart_id
                join product_children on cart_details.product_child_id = product_children.id
                where product_children.product_id = @ProductId and carts.customer_id = @CustomerId");
            builder.Where(@"product_id = @ProductId");
            var result = await _dbConnection.QueryMultipleAsync(@$"{productTemplate.RawSql};{inCartTemplate.RawSql};{template.RawSql}", request);
            var product = result.ReadFirstOrDefault<ProductDetailsDto>();
            if (product != null)
            {
                var quantityInCart = await result.ReadAsync<(Guid, IEnumerable<Guid>, uint)>();
                var children = await result.ReadAsync<ProductDetailsChildDto>();
                var attributes = new Dictionary<Guid, ProductDetailsAttributeDto>();
                result.Read<ProductDetailsAttributeDto, ProductDetailsAttributeValueDto, ProductDetailsAttributeDto>((attribute, value) =>
                {
                    value.QuantityInCart = Convert.ToUInt16(quantityInCart.Where(a => a.Item2.Contains(value.Id))?.Sum(a => a.Item3) ?? 0);
                    attributes.TryGetValue(attribute.Id, out var currAttribute);
                    if (currAttribute == null)
                    {
                        attribute.Values = new List<ProductDetailsAttributeValueDto>() { value };
                        attributes.Add(attribute.Id, attribute);
                    }
                    else
                    {
                        currAttribute.Values.Add(value);
                    }
                    return attribute;
                });
                product.Attributes = attributes.Values.OrderBy(a => a.Priority);
                product.Items = children.Select(a =>
                {
                    a.QuantityInCart = quantityInCart.FirstOrDefault(b => b.Item1 == a.Id).Item3;
                    return a;
                });
                product.ConfigAttributeQuantity();
            }
            return product;
        }
    }
}
