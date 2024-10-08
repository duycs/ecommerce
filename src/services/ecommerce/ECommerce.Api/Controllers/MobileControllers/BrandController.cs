using ECommerce.Application.Read.Queries.Brands;
using ECommerce.Shared.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers.MobileControllers
{
    public class BrandController : MobileControllerBase
    {
        private readonly IMediator _mediator;
        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("listTopHome")]
        public async Task<IActionResult> QueryBrands(int skip = 0, int take = 10)
        {
            var result = await _mediator.Send(new ListBrandsQuery(skip, take));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> QueryBrands()
        {
            var result = await _mediator.Send(new BrandsQuery());
            return Ok(result);
        }

        [HttpGet("topHome")]
        public async Task<IActionResult> QueryBrandsTopHome()
        {
            var result = await _mediator.Send(new BrandsTopHomeQuery());
            return Ok(result);
        }

        [HttpPost("byCategory")]
        public async Task<IActionResult> QueryBrandByCategory(BrandsByCategoryIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}



