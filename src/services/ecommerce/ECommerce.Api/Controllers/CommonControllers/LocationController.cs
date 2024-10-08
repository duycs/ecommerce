using ECommerce.Application.Models.Locations;
using ECommerce.Application.Read.Queries.LocationAggregate;
using ECommerce.Application.Read.Queries.SystemConfiguration;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers.CommonControllers
{
    public class LocationController : CommonControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _mediator.Send(new ListLocationsQuery());
            return Ok(result);
        }

        [HttpGet("version")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLocationsVersion()
        {
            var result = await _mediator.Send(new SystemConfigurationByKeyQuery(ConfigKeys.LocationVersion));
            return Ok(new LocationVersionDto(result.Value));
        }
    }
}
