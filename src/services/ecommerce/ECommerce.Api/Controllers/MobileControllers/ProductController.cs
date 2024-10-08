using ECommerce.Application.Read.Queries.Products;
using ECommerce.Shared.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using ECommerce.Shared.Constant;

namespace ECommerce.Api.Controllers.MobileControllers
{
    public class ProductController : MobileControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductDetails(Guid productId)
        {
            var result = await _mediator.Send(new ProductDetailsQuery(CurrentUserId, productId));
            return Ok(result);
        }

        [HttpGet("topHome")]
        public async Task<IActionResult> QueryTopProduct()
        {
            var productNews = await _mediator.Send(new TopNewProductsQuery());
            var productBestSelling = await _mediator.Send(new TopBestSellingProductsQuery());
            var productSuggests = await _mediator.Send(new TopSuggestedProductsQuery());
            var result = productNews.Items
                .Concat(productBestSelling.Items)
                .Concat(productSuggests.Items)
                .ToList();
            return Ok(result);
        }

        [HttpGet("listNew")]
        public async Task<IActionResult> QueryNewProducts(int skip, int take = 10)
        {
            var products = await _mediator.Send(new ListProductsTypeQuery(skip, take, ConfigKeys.NewProductTableName));
            return Ok(products);
        }

        [HttpGet("listBestSelling")]
        public async Task<IActionResult> QueryBestSellingProducts(int skip, int take = 10)
        {
            var products = await _mediator.Send(new ListProductsTypeQuery(skip, take, ConfigKeys.BestSellingProductTableName));
            return Ok(products);
        }

        [HttpGet("listSuggest")]
        public async Task<IActionResult> QuerySuggestProducts(int skip, int take = 10)
        {
            var products = await _mediator.Send(new ListProductsTypeQuery(skip, take, ConfigKeys.SuggestProductTableName));
            return Ok(products);
        }       

        //[HttpGet("purchaseProduct")]
        //public async Task<IActionResult> QueryPurchaseProduct(Guid customerId)
        //{
        //    var result = ;
        //    return Ok();
        //}

        [HttpPost("search")]
        public async Task<IActionResult> QuerySearchListProducts(SearchListProductsQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
