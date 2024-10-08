using ECommerce.Application.Read.Queries.Customers;
using ECommerce.Application.Write.Commands.Customers;
using ECommerce.Shared.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers.MobileControllers
{
    public class CustomerController : MobileControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerInfo()
        {
            var result = await _mediator.Send(new CustomerInfoQuery(CurrentUserId));
            return Ok(result);
        }

        #region Customer Address
        [HttpGet("address")]
        public async Task<IActionResult> QueryCustomerAddressListQuery()
        {
            var result = await _mediator.Send(new CustomerAddressListQuery(CurrentUserId));
            return Ok(result);
        }

        [HttpPost("address")]
        public async Task<IActionResult> CreateNewAddress(CreateCustomerAddressCommand command)
        {
            command.CustomerId = CurrentUserId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("address/{addressId}")]
        public async Task<IActionResult> EditAddress(Guid addressId, EditCustomerAddressCommand command)
        {
            command.CustomerId = CurrentUserId;
            command.AddressId = addressId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("address/{addressId}")]
        public async Task<IActionResult> DeleteAddress(Guid addressId)
        {
            var command = new DeleteCustomerAddressCommand(CurrentUserId, addressId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("address/{addressId}/default")]
        public async Task<IActionResult> SetDefaultAddress(Guid addressId)
        {
            var command = new SetDefaultCustomerAddressCommand(CurrentUserId, addressId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        #endregion

        [HttpGet("list")]
        public async Task<IActionResult> QueryCustomers(int skip = 0, int take = 10)
        {
            var result = await _mediator.Send(new ListCustomersQuery(skip, take));
            return Ok(result);
        }

        [HttpGet("currentLiabilities")]
        public async Task<IActionResult> QueryCustomerCurrentLiabilities()
        {
            var result = await _mediator.Send(new CustomerCurrentLiabilitiesQuery(CurrentUserId));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
        {
            command.CustomerId = CurrentUserId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
