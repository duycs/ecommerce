using ECommerce.Application.Write.Commands.Customers;
using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Infrastructure;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using EventBus.Abstractions;
using Integration.Events.CustomerEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Write.CommandHandlers.Customers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IECommerceUnitOfWork _uow;
        private readonly IEventBus _eventBus;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IECommerceUnitOfWork uow, IEventBus eventBus)
        {
            _customerRepository = customerRepository;
            _uow = uow;
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.InvalidCustomer);
            }
            customer.Update($@"{request.FirstName} {request.LastName}");
            _customerRepository.Update(customer);
            await _uow.SaveChangesAsync();
            _eventBus.Publish(new CustomerUpdatedIntegratedEvent()
            {
                CustomerId = customer.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
            });
            return Unit.Value;
        }
    }
}
