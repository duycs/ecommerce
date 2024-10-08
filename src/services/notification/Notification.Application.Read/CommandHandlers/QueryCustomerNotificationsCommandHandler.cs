using Dapper;
using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Notification.Application.DtoModels;
using Notification.Application.Read.Commands;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Read.CommandHandlers
{
    public class QueryCustomerNotificationsCommandHandler : IRequestHandler<QueryCustomerNotificationsCommand, QueryResult<NotificationDto>>
    {
        private readonly IDbConnection _db;

        public QueryCustomerNotificationsCommandHandler(IDbConnection db)
        {
            _db = db;
        }

        public async Task<QueryResult<NotificationDto>> Handle(QueryCustomerNotificationsCommand request, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"select count(id) from notification.notification_histories where user_id = @UserId;
                            select id, status, content, created_date, payload as payload_contents from notification.notification_histories 
                            where user_id = @UserId order by created_date desc 
                            offset @Skip rows fetch next @Take rows only;", request);

            var result = await _db.QueryMultipleAsync(template.RawSql, request);
            var count = result.ReadFirst<int>();
            var items = result.Read<NotificationDto>();
            return new QueryResult<NotificationDto>(count, items);
        }
    }
}
