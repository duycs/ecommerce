using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.Write.Commands
{
    public class MarkSeenAllNotificationsCommand : IRequest
    {
        public Guid UserId { get; private set; }

        public MarkSeenAllNotificationsCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
