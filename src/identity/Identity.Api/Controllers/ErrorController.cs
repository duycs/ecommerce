using ECommerce.Shared.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Identity.Api.Controllers
{
    public class ErrorController : ErrorControllerBase
    {
        public ErrorController(IStringLocalizer<ErrorControllerBase> localizer) : base(localizer)
        {
        }
    }
}
