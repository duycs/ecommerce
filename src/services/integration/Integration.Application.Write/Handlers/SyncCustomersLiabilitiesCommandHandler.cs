using Dapper;
using ECommerce.Shared.Dotnet.Specifications;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using Integration.Application.Write.Commands;
using Integration.Domain.AggregateModels.SystemLogAggregate;
using Integration.Domain.ECommerceAggregateModels;
using Integration.Domain.Enums;
using Integration.Infrastructure;
using MediatR;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Integration.Application.Write.Handlers
{
    public class SyncCustomersLiabilitiesCommandHandler : IRequestHandler<SyncCustomersLiabilitiesCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IECommerceUnitOfWork _uow;
        private readonly IDbConnection _db;
        private readonly ISystemLogRepository _systemLogRepository;

        public SyncCustomersLiabilitiesCommandHandler(ICustomerRepository customerRepository, IECommerceUnitOfWork uow, IDbConnection db, ISystemLogRepository systemLogRepository)
        {
            _customerRepository = customerRepository;
            _uow = uow;
            _db = db;
            _systemLogRepository = systemLogRepository;
        }

        public async Task<Unit> Handle(SyncCustomersLiabilitiesCommand request, CancellationToken cancellationToken)
        {
            SystemLog systemLog = new SystemLog("SyncCustomersLiabilitiesCommand", StatusLog.Successed.Id);
            systemLog.AddContentLog("request", request);

            var customerMappings = await _db.QueryAsync<(Guid, uint)>(@"select customer_id, old_id from integration.customer_mappings where old_id = any(@Ids)", new
            {
                Ids = request.Items.Select(i => Convert.ToInt32(i.Id)).ToArray()
            });
            if (customerMappings.IsNullOrEmpty())
            {
                await LogErrorDB(systemLog, "BusinessRuleException", ECommerceBusinessRule.NoCustomerMappingFound);
                throw new BusinessRuleException(ECommerceBusinessRule.NoCustomerMappingFound);
            }
            var customers = await _customerRepository.GetManyAsync(new Specification<Customer>(a => customerMappings.Select(p => p.Item1).Contains(a.Id)));
            foreach (var customerMapping in customerMappings)
            {
                var customer = customers.FirstOrDefault(a => a.Id == customerMapping.Item1);
                if (customer == null) continue;
                var liabilities = request.Items.First(a => a.Id == customerMapping.Item2);
                customer.UpdateLiabilities(liabilities.Liabilities, liabilities.MaxLiabilities);
                _customerRepository.Update(customer);
            }

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
