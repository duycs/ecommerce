using ECommerce.Application.Write.Commands.Carts;
using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Infrastructure;
using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Write.CommandHandlers.Carts
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IECommerceUnitOfWork _uow;

        public UpdateCartCommandHandler(ICartRepository cartRepository, IECommerceUnitOfWork uow)
        {
            _cartRepository = cartRepository;
            _uow = uow;
        }

        public async Task<Unit> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetSingleAsync(CartSpecs.GetByCustomerId(request.CustomerId));

            if (cart == null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.NoCartFound);
            }

            cart.UpdateQuantityDetails(request.Items);

            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
