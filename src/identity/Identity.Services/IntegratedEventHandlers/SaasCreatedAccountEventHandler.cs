using Dapper;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using EventBus.Abstractions;
using Identity.Domain.AccountAggregate;
using Integration.Events;
using Integration.Events.CustomerEvents;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Threading.Tasks;

namespace Identity.Services.IntegratedEventHandlers
{
    public class SaasCreatedAccountEventHandler : IIntegrationEventHandler<SaasCreatedAccountIntegratedEvent>
    {
        private readonly UserManager<Account> _userManager;
        private readonly IEventBus _eventBus;
        private readonly IDbConnection _connection;

        public SaasCreatedAccountEventHandler(UserManager<Account> userManager, IEventBus eventBus, IDbConnection connection)
        {
            _userManager = userManager;
            _eventBus = eventBus;
            _connection = connection;
        }

        public async Task Handle(SaasCreatedAccountIntegratedEvent @event)
        {
            if (await _userManager.FindByNameAsync(@event.UserName) != null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.UserNameExists);
            }
            var passwordValidator = new PasswordValidator<Account>();
            if (!(await passwordValidator.ValidateAsync(_userManager, null, "Abc@123")).Succeeded)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.PasswordInvalid);
            }
            if (@event.WardId.HasValue)
            {
                var exists = await _connection.ExecuteScalarAsync<bool>(@"select count(1) from public.wards where id = @WardId", new
                {
                    WardId = @event.WardId.Value,
                });
                if (!exists)
                {
                    throw new BusinessRuleException(ECommerceBusinessRule.WardNotExists);
                }
            }
            var account = new Account(@event.AccountId, @event.UserName, true, @event.FirstName, @event.LastName);
            await _userManager.CreateAsync(account, "Abc@123");
            var integratedEvent = new AccountCreatedIntegratedEvent()
            {
                WardId = @event.WardId,
                Address = @event.Address,
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                PhoneNumber = @event.UserName,
                UserId = account.Id
            };
            _eventBus.Publish(integratedEvent);
        }
    }
}
