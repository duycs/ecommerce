using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Infrastructure;
using EventBus.Abstractions;
using Integration.Events.CustomerEvents;
using System.Threading.Tasks;

namespace ECommerce.Services.IntegratedEventHandlers
{
    public class AccountCreatedEventHandler : IIntegrationEventHandler<AccountCreatedIntegratedEvent>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IECommerceUnitOfWork _uow;

        public AccountCreatedEventHandler(ICustomerRepository customerRepository, IECommerceUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public async Task Handle(AccountCreatedIntegratedEvent @event)
        {
            var customer = new Customer(@event.UserId, $@"{@event.FirstName} {@event.LastName}", @event.PhoneNumber);
            var defaultAddress = new CustomerAddress(@$"{@event.FirstName} {@event.LastName}", @event.PhoneNumber, @event.WardId, @event.Address);
            defaultAddress.SetDefault();
            customer.AddAddress(defaultAddress);
            _customerRepository.Add(customer);
            await _uow.SaveChangesAsync();
        }
    }
}
