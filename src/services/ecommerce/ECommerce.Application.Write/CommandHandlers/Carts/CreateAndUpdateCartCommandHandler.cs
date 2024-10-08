using ECommerce.Application.Write.Commands.Carts;
using ECommerce.Domain.AggregateModels.CartAggregate;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Infrastructure;
using ECommerce.Shared.Dotnet.Specifications;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Write.CommandHandlers.Carts
{
    public class CreateAndUpdateCartCommandHandler : IRequestHandler<CreateAndUpdateCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IECommerceUnitOfWork _uow;
        private readonly IProductRepository _productRepository;

        public CreateAndUpdateCartCommandHandler(ICartRepository cartRepository,
            IECommerceUnitOfWork uow,
            IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _uow = uow;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(CreateAndUpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetSingleAsync(CartSpecs.GetByCustomerId(request.CustomerId));
            var products = await _productRepository.GetChidren(new Specification<ProductChild>(a => request.Items.Select(b => b.Id).Contains(a.Id)));

            if (cart == null)
            {
                cart = new Cart(request.CustomerId);
                foreach (var item in request.Items)
                {
                    var child = products.FirstOrDefault(a => a.Id == item.Id);
                    if (child == null) continue;
                    cart.AddOrUpdateDetail(child, item.Quantity);
                }
                _cartRepository.Add(cart);
            }
            else
            {
                foreach (var item in request.Items)
                {
                    var child = products.FirstOrDefault(a => a.Id == item.Id);
                    if (child == null) continue;
                    cart.AddOrUpdateDetail(child, item.Quantity);
                }
                _cartRepository.Update(cart);
            } 
                await _uow.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
