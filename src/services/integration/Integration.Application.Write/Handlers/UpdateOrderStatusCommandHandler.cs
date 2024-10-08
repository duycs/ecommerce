using Dapper;
using ECommerce.Shared.Exceptions;
using Integration.Application.Write.Commands;
using Integration.Domain.OrderAggregateModels;
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
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand>
    {
        private readonly IDbConnection _db;
        private readonly IOrderRepository _orderRepository;
        private readonly IECommerceUnitOfWork _uow;
        private readonly ISystemLogRepository _systemLogRepository;

        public UpdateOrderStatusCommandHandler(IDbConnection db, IOrderRepository orderRepository, IECommerceUnitOfWork uow, ISystemLogRepository systemLogRepository)
        {
            _db = db;
            _orderRepository = orderRepository;
            _uow = uow;
            _systemLogRepository = systemLogRepository;
        }

        public async Task<Unit> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            SystemLog systemLog = new SystemLog("", StatusLog.Successed.Id);
            systemLog.AddContentLog("request", request);

            var mapping = await _db.QueryFirstOrDefaultAsync<Guid?>(@"select order_id from integration.order_mappings where old_id = @Id limit 1", new
            {
                Id = Convert.ToInt32(request.OrderId),
            });
            if (!mapping.HasValue)
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoOrderMappingFound);
                throw new BusinessRuleException(ECommerceBusinessRule.NoOrderMappingFound);
            }
            var order = await _orderRepository.GetByIdAsync(mapping.Value);
            if (order == null)
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoOrderFound);
                throw new BusinessRuleException(ECommerceBusinessRule.NoOrderFound);
            }
            order.UpdateStatus(request.OrderStatus);
            _orderRepository.Update(order);
            _systemLogRepository.Add(systemLog);

            await _uow.SaveChangesAsync();

            return Unit.Value;
        }

        private async Task LogErrorDB(SystemLog systemLog, string nameError, object contentError)
        {
            systemLog.AddContentLog(nameError, contentError);
            systemLog.SetStatus(StatusLog.Failed.Id);
            _systemLogRepository.Add(systemLog);

            await _uow.SaveChangesAsync();
        }
    }
}
