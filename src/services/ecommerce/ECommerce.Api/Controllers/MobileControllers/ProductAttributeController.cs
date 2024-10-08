using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Shared.Mvc;

namespace ECommerce.Api.Controllers.MobileControllers
{
    public class ProductAttributeController : MobileControllerBase
    {
        private readonly IMediator _mediator;

        public ProductAttributeController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
