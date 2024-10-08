using ECommerce.Shared.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Read.Queries.Products;
using System.Threading.Tasks;
using Order.Application.Read.Queries.Orders;

namespace Order.Api.Controllers.MobileController
{
    public class ProductController : MobileControllerBase
    {
        public readonly IMediator _mediator;

        public ProductController(IMediator meditor)
        {
            _mediator = meditor;
        }

        [HttpGet("topPurchased")]
        public async Task<IActionResult> QueryTopPurchaseProduct()
        {

            var result = await _mediator.Send(new TopPurchaseProductsQuery(CurrentUserId));
            return Ok(result.Items);
        }

        [HttpGet("listPurchased")]
        public async Task<IActionResult> QueryPurchaseProduct(int skip, int take)
        {
            var result = await _mediator.Send(new ListPurchaseProductsQuery(CurrentUserId, skip, take));
            return Ok(result);
        } 
    }
}
