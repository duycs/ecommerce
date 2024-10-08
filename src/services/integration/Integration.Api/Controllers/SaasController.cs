using ECommerce.Shared.Mvc;
using Integration.Application.Write.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SaasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SaasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("order/{orderId}/confirm")]
        public async Task<IActionResult> ConfirmOrder(uint orderId, ConfirmOrderCommand command)
        {
            command.OrderId = orderId;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("order/{orderId}/items")]
        public async Task<IActionResult> AddOrderItems(uint orderId, AddOrderItemsCommand command)
        {
            command.OrderId = orderId;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("order/{orderId}/items")]
        public async Task<IActionResult> EditOrderItemsQuantity(uint orderId, EditOrderItemsCommand command)
        {
            command.OrderId = orderId;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("order/{orderId}/items")]
        public async Task<IActionResult> RemoveOrderItems(uint orderId, RemoveOrderItemsCommand command)
        {
            command.OrderId = orderId;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("order/{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(uint orderId, UpdateOrderStatusCommand command)
        {
            command.OrderId = orderId;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("order/{orderId}/cancel")]
        public async Task<IActionResult> CancelOrder(uint orderId)
        {
            var command = new CancelOrderCommand(orderId);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("syncProductQuantities")]
        public async Task<IActionResult> SyncProductQuantities(SyncProductQuantitiesCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("customer")]
        public async Task<IActionResult> CreateNewCustomer(CreateNewCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("customer/liabilities")]
        public async Task<IActionResult> SyncCustomersLiabilities(SyncCustomersLiabilitiesCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("product/{productId}/images")]
        public async Task<IActionResult> SyncProductImages(uint productId, SyncProductImageCommand command)
        {
            command.ProductId = productId;
            await _mediator.Send(command);
            return Ok();
        }
    }
}
