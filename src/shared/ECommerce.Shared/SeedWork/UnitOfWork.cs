using ECommerce.Shared.Dotnet.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ECommerce.Shared.Mvc;
using ECommerce.Shared.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ECommerce.Shared.Dotnet.Interfaces;
using System.Reflection;

namespace ECommerce.Shared.SeedWork
{
    public abstract class UnitOfWork<TDbContext> : IUnitOfWork, IDisposable where TDbContext : BaseDbContext
    {
        private TDbContext _dbContext;

        private readonly ILogger<UnitOfWork<TDbContext>> _logger;

        protected readonly IMediator _mediator;

        protected readonly IScopeContext _scopeContext;

        protected UnitOfWork(TDbContext dbContext, ILogger<UnitOfWork<TDbContext>> logger, IMediator mediator, IScopeContext scopeContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            _logger = logger ?? throw new ArgumentNullException("logger");
            _mediator = mediator ?? throw new ArgumentNullException("mediator");
            _scopeContext = scopeContext;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await using IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                AddTrack();
                await _mediator.DispatchDomainEventsAsync(_dbContext, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unit of work commit failed");
                await transaction.RollbackAsync(cancellationToken);
                throw e;
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }

        private void AddTrack()
        {
            (from x in _dbContext.ChangeTracker.Entries()
             where x.State == EntityState.Added || x.State == EntityState.Modified
             select x).ToList().ForEach(delegate (EntityEntry entry)
             {
                 switch (entry.State)
                 {
                     case EntityState.Added:
                         (entry.Entity as IModifierTrackingEntity)?.MarkCreated(_scopeContext.CurrentAccountId, _scopeContext.CurrentAccountName);
                         (entry.Entity as IDateTrackingEntity)?.MarkCreated();
                         if (entry.Entity.GetType().GetCustomAttribute<PredefinedObjectAttribute>() != null)
                         {
                             entry.State = EntityState.Unchanged;
                         }

                         break;
                     case EntityState.Modified:
                         (entry.Entity as IDateTrackingEntity)?.MarkUpdated();
                         (entry.Entity as IModifierTrackingEntity)?.MarkModified(_scopeContext.CurrentAccountId, _scopeContext.CurrentAccountName);
                         if (entry.Entity.GetType().GetCustomAttribute<PredefinedObjectAttribute>() != null)
                         {
                             entry.State = EntityState.Unchanged;
                         }

                         break;
                     default:
                         throw new ArgumentOutOfRangeException();
                     case EntityState.Detached:
                     case EntityState.Unchanged:
                     case EntityState.Deleted:
                         break;
                 }
             });
        }
    }
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
