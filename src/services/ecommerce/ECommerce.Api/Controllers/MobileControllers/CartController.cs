using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Shared.Mvc;
using System.Threading.Tasks;
using ECommerce.Application.Write.Commands.Carts;
using ECommerce.Application.Read.Queries.Carts;

namespace ECommerce.Api.Controllers.MobileControllers
{
    public class CartController : MobileControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("order")]
        public async Task<IActionResult> Order(OrderCommand command)
        {
            command.SetCustomerId(CurrentUserId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddAndUpdate(CreateAndUpdateCartCommand command)
        {
            command.CustomerId = CurrentUserId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("items")]
        public async Task<IActionResult> UpdateItems(UpdateCartCommand command)
        {
            command.CustomerId = CurrentUserId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("items")]
        public async Task<IActionResult> RemoveItems(RemoveDetailCommand command)
        {
            command.CustomerId = CurrentUserId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetItems()
        {
            var result = await _mediator.Send(new DetailsQuery(CurrentUserId));
            return Ok(result);
        }

        [HttpGet("totalQuantityItems")]
        public async Task<IActionResult> TotalQuantityItemsQuery()
        {
            var result = await _mediator.Send(new TotalQuantityDetailsQuery(CurrentUserId));
            return Ok(result);
        }

       [HttpGet("infoBank")]
       public async Task<IActionResult> InfoBankQuery()
        {
            var result = await _mediator.Send(new InfoBankQuery());
            return Ok(result);
        }
    }
}
