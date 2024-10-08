using ECommerce.Shared.Mvc;
using Microsoft.Extensions.Localization;

namespace Notification.Api.Controllers
{
    public class ErrorController : ErrorControllerBase
    {
        public ErrorController(IStringLocalizer<ErrorControllerBase> localizer) : base(localizer)
        {
        }
    }
}
