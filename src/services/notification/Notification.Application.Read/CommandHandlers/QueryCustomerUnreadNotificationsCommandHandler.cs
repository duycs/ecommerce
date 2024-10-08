using Dapper;
using MediatR;
using Notification.Application.Read.Commands;
using Notification.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Read.CommandHandlers
{
    public class QueryCustomerUnreadNotificationsCommandHandler : IRequestHandler<QueryCustomerUnreadNotificationsCommand, int>
    {
        private readonly IDbConnection _db;

        public QueryCustomerUnreadNotificationsCommandHandler(IDbConnection db)
        {
            _db = db;
        }

        public async Task<int> Handle(QueryCustomerUnreadNotificationsCommand request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"select count(id) from notification.notification_histories where user_id = @UserId and status = @UnreadStatus");
            var result = await _db.QueryFirstOrDefaultAsync<int>(template.RawSql, new
            {
                UserId = request.CustomerId,
                UnreadStatus = NotificationStatus.UnSeen.Id
            });
            return result;
        }
    }
}
