using ECommerce.Shared.Mvc;
using ECommerce.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Synchronize.Infrastructure
{
    public class SynchronizeUnitOfWork : UnitOfWork<ECommerceDbContext>, ISynchronizeUnitOfWork
    {
        public SynchronizeUnitOfWork(ECommerceDbContext dbContext, ILogger<UnitOfWork<ECommerceDbContext>> logger, IMediator mediator, IScopeContext scopeContext) : base(dbContext, logger, mediator, scopeContext)
        {
        }
    }
}
