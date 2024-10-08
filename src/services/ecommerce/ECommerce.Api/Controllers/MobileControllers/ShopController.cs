using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Shared.Mvc;

namespace ECommerce.Api.Controllers.MobileControllers
{
    public class ShopController : MobileControllerBase
    {
        private readonly IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
