using ECommerce.Shared.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Read.Queries.Orders;
using Order.Application.Write.Commands.Orders;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Order.Api.Controllers.MobileController
{
    public class OrderController : MobileControllerBase
    {
        public readonly IMediator _mediator;

        public OrderController(IMediator meditor)
        {
            _mediator = meditor;
        }

        [HttpGet("histories")]
        public async Task<IActionResult> QueryOrderHistory(DateTime? fromDate, DateTime? toDate, string orderCode)
        {
            var result = await _mediator.Send(new OrderHistoriesQuery(fromDate, toDate, orderCode, CurrentUserId));
            return Ok(result.Items);
        }
        [HttpGet("historyStatus")]
        public async Task<IActionResult> QueryOrderHistoryStatus(DateTime? fromDate, DateTime? toDate, string orderCode, int statusId, int skip, int take)
        {
            var result = await _mediator.Send(new OrderHistoryStatusQuery(CurrentUserId, fromDate, toDate, orderCode, statusId, skip, take));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> QueryOrderDetail(Guid id)
        {
            var result = await _mediator.Send(new OrderDetailQuery(id, CurrentUserId));
            return Ok(result.Items.FirstOrDefault());
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            var result = await _mediator.Send(new CancelOrderCommand(id, CurrentUserId));

            return Ok(result);
        }

        [HttpPut("{id}/info")]
        public async Task<IActionResult> UpdateInfo(Guid id, ChangeInfoCommand command)
        {
            command.Id = id;
            command.CustomerId = CurrentUserId;
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("productsInOrder/{id}")]
        public async Task<IActionResult> QueryProductInOrder(Guid id)
        {
            var result = await _mediator.Send(new ProductsInOrderQuery(id, CurrentUserId));
            return Ok(result.Items);
        }
        [HttpGet("listLiability")]
        public async Task<IActionResult> QueryLiabilitiList(int skip, int take)
        {
            var result = await _mediator.Send(new ListLiabilityQuery(CurrentUserId, skip, take));
            return Ok(result);
        }
    }
}
