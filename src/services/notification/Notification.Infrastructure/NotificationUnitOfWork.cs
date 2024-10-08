using ECommerce.Shared.Mvc;
using ECommerce.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Notification.Infrastructure
{
    public class NotificationUnitOfWork : UnitOfWork<NotificationDbContext>, INotificationUnitOfWork
    {
        public NotificationUnitOfWork(NotificationDbContext dbContext, ILogger<UnitOfWork<NotificationDbContext>> logger, IMediator mediator, IScopeContext scopeContext) : base(dbContext, logger, mediator, scopeContext)
        {
        }
    }
}
