using ECommerce.Shared.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Integration.Api.Controllers
{
    public class ErrorController : ErrorControllerBase
    {
        public ErrorController(IStringLocalizer<ErrorControllerBase> localizer) : base(localizer)
        {
        }
    }
}
