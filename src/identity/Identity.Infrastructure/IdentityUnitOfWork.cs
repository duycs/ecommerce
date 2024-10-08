using ECommerce.Shared.Mvc;
using ECommerce.Shared.SeedWork;
using Identity.Domain.AccountAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Identity.Infrastructure
{
    public class IdentityUnitOfWork : IdentityUnitOfWork<ECommerceIdentityDbContext, Account, Role>, IIdentityUnitOfWork
    {
        public IdentityUnitOfWork(ECommerceIdentityDbContext dbContext, ILogger<IdentityUnitOfWork<ECommerceIdentityDbContext, Account, Role>> logger, IMediator mediator, IScopeContext scopeContext) : base(dbContext, logger, mediator, scopeContext)
        {
        }

    } 
}
