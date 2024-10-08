using ECommerce.Shared.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Net;

namespace ECommerce.Api.Controllers
{
    public class ErrorController : ErrorControllerBase
    {
        public ErrorController(IStringLocalizer<ErrorControllerBase> localizer) : base(localizer)
        {
        }
    }
}
