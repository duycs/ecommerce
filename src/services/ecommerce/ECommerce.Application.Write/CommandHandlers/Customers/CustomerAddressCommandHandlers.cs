using ECommerce.Application.Write.Commands.Customers;
using ECommerce.Domain.AggregateModels.CustomerAggregate;
using ECommerce.Infrastructure;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Write.CommandHandlers.Customers
{
    public class CustomerAddressCommandHandlers :
        IRequestHandler<CreateCustomerAddressCommand>,
        IRequestHandler<EditCustomerAddressCommand>,
        IRequestHandler<DeleteCustomerAddressCommand>,
        IRequestHandler<SetDefaultCustomerAddressCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IECommerceUnitOfWork _uow;

        public CustomerAddressCommandHandlers(ICustomerRepository customerRepository, IECommerceUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await GetCustomer(request.CustomerId);
            var address = new CustomerAddress(request.ReceiverName, request.ReceiverPhoneNumber, request.WardId, request.Address);
            customer.AddAddress(address);
            _customerRepository.Update(customer);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(EditCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await GetCustomer(request.CustomerId);
            var address = customer.GetAddress(request.AddressId);
            if (address == null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.InvalidCustomer);
            }
            address.Update(request.ReceiverName, request.ReceiverPhoneNumber, request.WardId, request.Address);
            _customerRepository.Update(customer);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await GetCustomer(request.CustomerId);
            customer.DeleteAddress(request.AddressId);
            _customerRepository.Update(customer);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(SetDefaultCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await GetCustomer(request.CustomerId);
            customer.SetDefaultAddress(request.AddressId);
            _customerRepository.Update(customer);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }

        private async Task<Customer> GetCustomer(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.InvalidCustomer);
            }
            return customer;
        }
    }
}
