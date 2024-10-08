using Dapper;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using EventBus.Abstractions;
using Integration.Application.Write.Commands;
using Integration.Domain.AggregateModels;
using Integration.Domain.AggregateModels.SystemLogAggregate;
using Integration.Domain.Enums;
using Integration.Events;
using Integration.Infrastructure;
using MediatR;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Integration.Application.Write.Handlers
{
    public class CreateNewCustomerCommandHandler : IRequestHandler<CreateNewCustomerCommand>
    {
        private readonly IDbConnection _db;
        private readonly ICustomerMappingRepository _repository;
        private readonly IEventBus _eventBus;
        private readonly IECommerceUnitOfWork _uow;
        private readonly ISystemLogRepository _systemLogRepository;

        public CreateNewCustomerCommandHandler(IDbConnection db, ICustomerMappingRepository repository, IECommerceUnitOfWork uow, IEventBus eventBus, ISystemLogRepository systemLogRepository)
        {
            _db = db;
            _repository = repository;
            _uow = uow;
            _eventBus = eventBus;
            _systemLogRepository = systemLogRepository;
        }

        public async Task<Unit> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            SystemLog systemLog = new SystemLog("CreateNewCustomerCommandHandler", StatusLog.Failed.Id);
            systemLog.AddContentLog("request", request);

            var query = await _db.QueryMultipleAsync(@"select customer_id from integration.customer_mappings where old_id = @Id limit 1;
                            select id from public.wards where code = @Code limit 1;
                            select ""Id"" from identity.""AspNetUsers"" where ""UserName"" = @UserName limit 1", new
            {
                Id = Convert.ToInt32(request.CustomerId),
                Code = request.WardCode,
                request.UserName,
            });

            var customerId = query.ReadFirstOrDefault<Guid?>();
            var wardId = query.ReadFirstOrDefault<Guid?>();
            var userId = query.ReadFirstOrDefault<Guid?>();

            if (customerId.HasValue)
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.AccountExists);
                throw new BusinessRuleException(ECommerceBusinessRule.AccountExists);
            }

            if (userId.HasValue)
            {
                _repository.Add(new CustomerMapping(userId.Value, request.CustomerId));
                await _uow.SaveChangesAsync();
                return Unit.Value;
            }

            var newAccountId = Guid.NewGuid();

            var customerMapping = new CustomerMapping(newAccountId, request.CustomerId);
            _repository.Add(customerMapping);    
            _systemLogRepository.Add(systemLog);

            await _uow.SaveChangesAsync();

            var integratedEvent = new SaasCreatedAccountIntegratedEvent()
            {
                AccountId = newAccountId,
                UserName = request.UserName,
                WardId = wardId,
                Address = request.Address,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _eventBus.Publish(integratedEvent);
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
