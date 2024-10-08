using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.Write.Commands
{
    public class MarkSeenNotificationCommand : IRequest
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }

        public MarkSeenNotificationCommand(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
