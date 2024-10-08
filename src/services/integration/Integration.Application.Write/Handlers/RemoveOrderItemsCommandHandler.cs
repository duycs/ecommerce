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
using Integration.Domain.AggregateModels.SystemLogAggregate;
using Integration.Domain.Enums;
using ECommerce.Shared.Dotnet.Specifications;

namespace Integration.Application.Write.Handlers
{
    public class RemoveOrderItemsCommandHandler : IRequestHandler<RemoveOrderItemsCommand>
    {
        private readonly IDbConnection _db;
        private readonly IProductChildRepository _productChildRepository;
        private readonly IECommerceUnitOfWork _ecomUow;
        private readonly IOrderRepository _orderRepository;
        private readonly ISystemLogRepository _systemLogRepository;

        public RemoveOrderItemsCommandHandler(IDbConnection db, IProductChildRepository productChildRepository, IECommerceUnitOfWork ecomUow, IOrderRepository orderRepository, ISystemLogRepository systemLogRepository)
        {
            _db = db;
            _productChildRepository = productChildRepository;
            _ecomUow = ecomUow;
            _orderRepository = orderRepository;
            _systemLogRepository = systemLogRepository;
        }

        public async Task<Unit> Handle(RemoveOrderItemsCommand request, CancellationToken cancellationToken)
        {
            SystemLog systemLog = new SystemLog("RemoveOrderItemsCommandHandler", StatusLog.Successed.Id);
            systemLog.AddContentLog("request", request);

            var query = await _db.QueryMultipleAsync(@"select order_id from integration.order_mappings where old_id = @Id limit 1;
                                select child_product_id, old_id from integration.child_product_mappings where old_id = any(@Ids)", new
            {
                Id = Convert.ToInt32(request.OrderId),
                Ids = request.ProductChildIds.Select(i => Convert.ToInt32(i)).ToArray()
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
            foreach (var productMapping in productMappings)
            {
                var childProduct = childProducts.FirstOrDefault(a => a.Id == productMapping.Item1);
                if (childProduct == null) continue;

                var quantity = order.GetDetailQuantity(childProduct.Id);
                if (!quantity.HasValue) continue;
                order.RemoveDetail(childProduct.Id);
                childProduct.AddQuantity(quantity.Value);
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
}
