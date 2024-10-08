using ECommerce.Application.Write.Commands.Customers;
using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Infrastructure;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Write.CommandHandlers.Customers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IECommerceUnitOfWork _uow;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IECommerceUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.InvalidCustomer);
            }
            _customerRepository.Delete(customer);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
