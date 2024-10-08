using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Application.Write.Commands.Customers
{
    public class CreateCustomerAddressCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public Guid? WardId { get; set; }
        public string Address { get; set; }
    }

    public class DeleteCustomerAddressCommand : IRequest
    {
        public Guid CustomerId { get; private set; }
        public Guid AddressId { get; private set; }

        public DeleteCustomerAddressCommand(Guid customerId, Guid addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }
    }

    public class EditCustomerAddressCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        [Required]
        [Phone]
        public string ReceiverPhoneNumber { get; set; }
        public Guid? WardId { get; set; }
        [Required]
        public string Address { get; set; }
    }

    public class SetDefaultCustomerAddressCommand : IRequest
    {
        public Guid CustomerId { get; private set; }
        public Guid AddressId { get; private set; }

        public SetDefaultCustomerAddressCommand(Guid customerId, Guid addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }
    }
}
