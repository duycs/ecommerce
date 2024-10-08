using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Notification.Application.DtoModels;
using System;

namespace Notification.Application.Read.Commands
{
    public class QueryCustomerNotificationsCommand : IRequest<QueryResult<NotificationDto>>
    {
        public Guid UserId { get; private set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public QueryCustomerNotificationsCommand(Guid userId, int skip, int take)
        {
            UserId = userId;
            Skip = skip;
            Take = take;
        }
    }
}
