using Dapper;
using ECommerce.Shared.Exceptions;
using Integration.Application.Write.Commands;
using Integration.Domain.ECommerceAggregateModels;
using Integration.Infrastructure;
using MediatR;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Shared.Extensions;
using Integration.Domain.AggregateModels.SystemLogAggregate;
using Integration.Domain.Enums;

namespace Integration.Application.Write.Handlers
{
    public class SyncProductImageCommandHandler : IRequestHandler<SyncProductImageCommand>
    {
        private readonly IDbConnection _db;
        private readonly IProductRepository _productRepository;
        private readonly IECommerceUnitOfWork _ecomUow;
        private readonly ISystemLogRepository _systemLogRepository;

        public SyncProductImageCommandHandler(IDbConnection db, IProductRepository productRepository, IECommerceUnitOfWork ecomUow, ISystemLogRepository systemLogRepository)
        {
            _db = db;
            _productRepository = productRepository;
            _ecomUow = ecomUow;
            _systemLogRepository = systemLogRepository;
        }

        public async Task<Unit> Handle(SyncProductImageCommand request, CancellationToken cancellationToken)
        {
            SystemLog systemLog = new SystemLog("SyncProductImageCommandHandler", StatusLog.Successed.Id);
            systemLog.AddContentLog("request", request);
            var mapping = await _db.QueryFirstOrDefaultAsync<(Guid, uint)>(@"select product_id, old_id from integration.product_mappings where old_id = @Id limit 1", new
            {
                Id = Convert.ToInt32(request.ProductId)
            });
            if (mapping == default)
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoProductMappingFound);
                throw new BusinessRuleException(ECommerceBusinessRule.NoProductMappingFound);
            }
            var product = await _productRepository.GetByIdAsync(mapping.Item1);
            product.UpdateImages(request.Images);
            _productRepository.Update(product);
            _systemLogRepository.Add(systemLog);

            try
            {
                await _ecomUow.SaveChangesAsync();
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
