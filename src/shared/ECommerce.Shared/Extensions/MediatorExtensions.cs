using ECommerce.Shared.Dotnet.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace ECommerce.Shared.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<EntityEntry<IChangeTrackingEntity>> source = (from x in ctx.ChangeTracker.Entries<IChangeTrackingEntity>()
                                                               where x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()
                                                               select x).ToList();
            List<INotification> list = source.SelectMany((EntityEntry<IChangeTrackingEntity> x) => x.Entity.DomainEvents).ToList();
            source.ToList().ForEach(delegate (EntityEntry<IChangeTrackingEntity> entity)
            {
                entity.Entity.ClearDomainEvents();
            });
            foreach (INotification item in list)
            {
                await mediator.Publish(item, cancellationToken);
            }
        }
    }
}
