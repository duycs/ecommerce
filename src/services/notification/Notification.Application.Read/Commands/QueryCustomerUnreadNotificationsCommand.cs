using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.Read.Commands
{
    public class QueryCustomerUnreadNotificationsCommand : IRequest<int>
    {
        public Guid CustomerId { get; private set; }

        public QueryCustomerUnreadNotificationsCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
