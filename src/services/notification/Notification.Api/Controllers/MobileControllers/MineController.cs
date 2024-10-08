using ECommerce.Shared.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Read.Commands;
using Notification.Application.Write.Commands;
using System;
using System.Threading.Tasks;

namespace Notification.Api.Controllers.MobileControllers
{
    public class MineController : MobileControllerBase
    {
        private readonly IMediator _mediator;

        public MineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyListNotifications(int skip = 0, int take = 10)
        {
            var command = new QueryCustomerNotificationsCommand(CurrentUserId, skip, take);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{notificationId}/seen")]
        public async Task<IActionResult> MarkNotificationAsSeen(Guid notificationId)
        {
            var command = new MarkSeenNotificationCommand(notificationId, CurrentUserId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("seenAll")]
        public async Task<IActionResult> MarkAllNotificationsAsSeen()
        {
            var command = new MarkSeenAllNotificationsCommand(CurrentUserId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("unRead")]
        public async Task<IActionResult> GetCountUnreadNotifications()
        {
            var command = new QueryCustomerUnreadNotificationsCommand(CurrentUserId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
