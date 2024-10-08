using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using MediatR;
using Notification.Application.Write.Commands;
using Notification.Domain.AggregateModels.NotificationAggregate;
using Notification.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Write.CommandHandlers
{
    public class MarkSeenNotificationCommandHandler : IRequestHandler<MarkSeenNotificationCommand>
    {
        private readonly INotificationHistoryRepository _repo;
        private readonly INotificationUnitOfWork _uow;

        public MarkSeenNotificationCommandHandler(INotificationHistoryRepository repo, INotificationUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Unit> Handle(MarkSeenNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _repo.GetSingleAsync(NotificationHistorySpecs.ByIdAndUserId(request.Id, request.CustomerId));
            if (notification == null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.NoNotificationFound);
            }
            notification.Seen();
            _repo.Update(notification);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
