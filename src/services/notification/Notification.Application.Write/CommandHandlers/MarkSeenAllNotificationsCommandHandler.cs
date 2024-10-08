using MediatR;
using Notification.Application.Write.Commands;
using Notification.Domain.AggregateModels.NotificationAggregate;
using Notification.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Write.CommandHandlers
{
    public class MarkSeenAllNotificationsCommandHandler : IRequestHandler<MarkSeenAllNotificationsCommand>
    {
        private readonly INotificationHistoryRepository _repo;
        private readonly INotificationUnitOfWork _uow;

        public MarkSeenAllNotificationsCommandHandler(INotificationHistoryRepository repo, INotificationUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Unit> Handle(MarkSeenAllNotificationsCommand request, CancellationToken cancellationToken)
        {
            var specs = NotificationHistorySpecs.ByUserId(request.UserId);
            var notifications = await _repo.GetManyAsync(specs);
            foreach (var notification in notifications)
            {
                notification.Seen();
                _repo.Update(notification);
            }
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
