using ECommerce.Shared.Mvc;
using ECommerce.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure
{
    public class ECommerceUnitOfWork : UnitOfWork<ECommerceDbContext>, IECommerceUnitOfWork
    {
        public ECommerceUnitOfWork(ECommerceDbContext dbContext, ILogger<UnitOfWork<ECommerceDbContext>> logger, IMediator mediator, IScopeContext scopeContext) : base(dbContext, logger, mediator, scopeContext)
        {
        }
    }
}
