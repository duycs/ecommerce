using EventBus.Abstractions;
using Identity.Domain.AccountAggregate;
using Integration.Events.CustomerEvents;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Identity.Services.IntegratedEventHandlers
{
    public class CustomerUpdatedEventHandler : IIntegrationEventHandler<CustomerUpdatedIntegratedEvent>
    {
        private readonly UserManager<Account> _userManager;

        public CustomerUpdatedEventHandler(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        public async Task Handle(CustomerUpdatedIntegratedEvent @event)
        {
            var account = await _userManager.FindByIdAsync(@event.CustomerId.ToString());
            if (account != null)
            {
                account.Update(@event.FirstName, @event.LastName);
                await _userManager.UpdateAsync(account);
            }
        }
    }
}
