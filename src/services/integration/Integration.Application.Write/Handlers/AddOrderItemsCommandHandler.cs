using Dapper;
using ECommerce.Shared.Exceptions;
using Integration.Application.Write.Commands;
using Integration.Domain.ECommerceAggregateModels;
using Integration.Domain.OrderAggregateModels;
using Integration.Infrastructure;
using MediatR;
using System;
using System.Linq;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Shared.Extensions;
using System.Collections.Generic;
using Integration.Domain.AggregateModels.SystemLogAggregate;
using Integration.Domain.Enums;
using ECommerce.Shared.Dotnet.Specifications;

namespace Integration.Application.Write.Handlers
{
    public class AddOrderItemsCommandHandler : IRequestHandler<AddOrderItemsCommand>
    {
        private readonly IDbConnection _db;
        private readonly IProductChildRepository _productChildRepository;
        private readonly IECommerceUnitOfWork _ecomUow;
        private readonly IOrderRepository _orderRepository;
        private readonly ISystemLogRepository _systemLogRepository;

        public AddOrderItemsCommandHandler(IDbConnection dbConnection,
            IProductChildRepository productChildRepository,
            IECommerceUnitOfWork ecomUow,
            IOrderRepository orderRepository,
            ISystemLogRepository systemLogRepository)
        {
            _db = dbConnection;
            _productChildRepository = productChildRepository;
            _ecomUow = ecomUow;
            _orderRepository = orderRepository;
            _systemLogRepository = systemLogRepository;
        }

        public async Task<Unit> Handle(AddOrderItemsCommand request, CancellationToken cancellationToken)
        {
            SystemLog systemLog = new SystemLog("AddOrderItemsCommandHandler", StatusLog.Successed.Id);
            var contentlogs = systemLog.Contents;
            systemLog.AddContentLog("request", request);

            var query = await _db.QueryMultipleAsync(@"select order_id from integration.order_mappings where old_id = @Id limit 1;
                                select child_product_id, old_id from integration.child_product_mappings where old_id = any(@Ids)", new
            {
                Id = Convert.ToInt32(request.OrderId),
                Ids = request.Items.Select(i => Convert.ToInt32(i.ProductChildId)).ToArray()
            });
            var orderMapping = query.ReadFirstOrDefault<Guid?>();
            var productMappings = query.Read<(Guid, uint)>();
            if (!orderMapping.HasValue)
            {
                 await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoOrderMappingFound);

                throw new BusinessRuleException(ECommerceBusinessRule.NoOrderMappingFound);
            }
            if (productMappings.IsNullOrEmpty())
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoProductMappingFound);

                throw new BusinessRuleException(ECommerceBusinessRule.NoProductMappingFound);
            }
            var order = await _orderRepository.GetByIdAsync(orderMapping.Value);
            if (order == null)
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoOrderFound);

                throw new BusinessRuleException(ECommerceBusinessRule.NoOrderFound);
            }
            var childProducts = await _productChildRepository.GetManyAsync(new Specification<ProductChild>(a => productMappings.Select(p => p.Item1).Contains(a.Id)));
            var childDetailsQuery = await _db.QueryMultipleAsync(@"select pc.id as product_child_id, pc.name as product_child_name, pc.sku as product_child_sku, pc.attribute_value_ids,
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
            where pa.product_id = Any(@ProductIds)", new
            {
                ProductChildIds = childProducts.Select(a => a.Id).ToArray(),
                ProductIds = childProducts.Select(a => a.ProductId).ToArray()
            });

            var childDetails = await childDetailsQuery.ReadAsync<ProductChildDetailDto>();
            var childPrices = await childDetailsQuery.ReadAsync<ProductChildPriceDto>();
            var childAttrValues = await childDetailsQuery.ReadAsync<ProductAttributeValue>();

            foreach (var productMapping in productMappings)
            {
                var childProduct = childProducts.FirstOrDefault(a => a.Id == productMapping.Item1);
                if (childProduct == null) continue;
                var quantity = request.Items.First(a => a.ProductChildId == productMapping.Item2).Quantity;
                var productDetail = childDetails.First(a => a.ProductChildId == productMapping.Item1);
                var price = childPrices.FirstOrDefault(a => a.ProductChildId == productMapping.Item1 && (!a.IsLimitQuantity || (a.QuantityTo <= quantity && a.QuantityFrom >= quantity)));

                var orderDetail = new OrderDetail(quantity, price?.Price ?? 0, price?.PriceDiscount ?? 0,
                    productDetail.ProductId, productDetail.ProductSku, productDetail.ProductName,
                    productDetail.ProductChildId, productDetail.ProductChildName, productDetail.ProductChildSku,
                    productDetail.BrandId, productDetail.BrandName,
                    productDetail.ProductCategoryId, productDetail.ProductCategoryName,
                    productDetail.ShopId, productDetail.ShopName);
                orderDetail.AddAttributeValues(childAttrValues.Where(a => productDetail.AttributeValueIds.Contains(a.Id)).ToList());

                order.AddDetail(orderDetail);
                childProduct.RemoveQuantity(quantity);
                _productChildRepository.Update(childProduct);
            }
            _orderRepository.Update(order);
            _systemLogRepository.Add(systemLog);
            try
            {
                await _ecomUow.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                await LogErrorDB(systemLog, "DBConcurrencyException", ECommerceBusinessRule.QuantityUpdated);

                throw new BusinessRuleException(ECommerceBusinessRule.QuantityUpdated);
            }
            catch (Exception ex)
            {
                await LogErrorDB(systemLog, "Exception", ex);
                throw ex;
            }
            return Unit.Value;
        }

        private async Task LogErrorDB(SystemLog systemLog, string nameError, object contentError)
        {
            systemLog.AddContentLog(nameError, contentError);
            systemLog.SetStatus(StatusLog.Failed.Id);
            _systemLogRepository.Add(systemLog);

            await _ecomUow.SaveChangesAsync();
        }
    }

    public class ProductChildDetailDto
    {
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
