using ECommerce.Application.Read.Queries.ProductCategories;
using ECommerce.Application.Read.Queries.SystemConfiguration;
using ECommerce.Shared.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers.MobileControllers
{
    public class ProductCategoryController : MobileControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("listTopHome")]
        public async Task<IActionResult> QueryProductCategories(int skip = 0, int take = 10)
        {
            var result = await _mediator.Send(new ListProductCategoriesQuery(skip, take));
            return Ok(result);
        }

        [HttpGet("topHome")]
        public async Task<IActionResult> QueryTopProductCategories()
        {
            var result = await _mediator.Send(new TopProductCategoriesQuery());
            return Ok(result.Items);
        }
        [HttpGet("byParrentId")]
        public async Task<IActionResult> QueryByParrentId(Guid parentId)
        {
            var result = await _mediator.Send(new CategoriesByParrentQuery(parentId));
            return Ok(result);
        }

        [HttpGet("parents")]
        public async Task<IActionResult> QueryParentProductCategories()
        {
            var result = await _mediator.Send(new ProductCategoriesQuery());
            return Ok(result);
        }
    }
}
