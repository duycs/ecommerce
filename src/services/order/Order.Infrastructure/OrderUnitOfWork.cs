using ECommerce.Shared.Mvc;
using ECommerce.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Order.Infrastructure
{
    public class OrderUnitOfWork : UnitOfWork<OrderDbContext>, IOrderUnitOfWork
    {
        public OrderUnitOfWork(OrderDbContext dbContext, ILogger<UnitOfWork<OrderDbContext>> logger, IMediator mediator, IScopeContext scopeContext) : base(dbContext, logger, mediator, scopeContext)
        {
        }
    }
}
