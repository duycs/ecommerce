using Dapper;
using ECommerce.Shared.Exceptions;
using Integration.Application.Write.Commands;
using Integration.Domain.ECommerceAggregateModels;
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
    public class SyncProductQuantitiesCommandHandler : IRequestHandler<SyncProductQuantitiesCommand>
    {
        private readonly IDbConnection _db;
        private readonly IProductChildRepository _productChildRepository;
        private readonly IECommerceUnitOfWork _ecomUow;
        private readonly ISystemLogRepository _systemLogRepository;

        public SyncProductQuantitiesCommandHandler(IDbConnection db, IProductChildRepository productChildRepository, IECommerceUnitOfWork ecomUow, ISystemLogRepository systemLogRepository)
        {
            _db = db;
            _productChildRepository = productChildRepository;
            _ecomUow = ecomUow;
            _systemLogRepository = systemLogRepository;
        }

        public async Task<Unit> Handle(SyncProductQuantitiesCommand request, CancellationToken cancellationToken)
        {
            SystemLog systemLog = new SystemLog("SyncProductQuantitiesCommandHandler", StatusLog.Successed.Id);
            systemLog.AddContentLog("request", request);
            var productMappings = await _db.QueryAsync<(Guid, uint)>(@"select child_product_id, old_id from integration.child_product_mappings where old_id = any(@Ids)", new
            {
                Ids = request.Items.Select(i => Convert.ToInt32(i.Id)).ToArray()
            });
            if (productMappings.IsNullOrEmpty())
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoProductMappingFound);
                throw new BusinessRuleException(ECommerceBusinessRule.NoProductMappingFound);
            }
            var childProducts = await _productChildRepository.GetManyAsync(new Specification<ProductChild>(a => productMappings.Select(p => p.Item1).Contains(a.Id)));
            foreach (var productMapping in productMappings)
            {
                var childProduct = childProducts.FirstOrDefault(a => a.Id == productMapping.Item1);
                if (childProduct == null) continue;
                var quantity = request.Items.First(a => a.Id == productMapping.Item2).Quantity;
                childProduct.ChangeQuantity(quantity);
                _productChildRepository.Update(childProduct);
            }
            _systemLogRepository.Add(systemLog);
            try
            {
                await _ecomUow.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.QuantityUpdated);
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
