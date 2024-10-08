using ECommerce.Shared.Exceptions;
using ECommerce.Shared.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ECommerce.Shared.Mvc
{
    public abstract class ErrorControllerBase : ControllerBase
    {
        private readonly IStringLocalizer<ErrorControllerBase> _localizer;

        public ErrorControllerBase(IStringLocalizer<ErrorControllerBase> localizer)
        {
            _localizer = localizer;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            switch (context.Error)
            {
                case ValidationException validationException:
                    var modelState = validationException.GetModelState(_localizer);
                    return ValidationProblem(modelState);
                case BusinessRuleException businessRuleException:
                    return Problem(statusCode: StatusCodes.Status400BadRequest, title: _localizer[businessRuleException.Message], detail: businessRuleException.StackTrace, type: businessRuleException.Rule.Code.ToString());
                default:
                    return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: context.Error.StackTrace, title: context.Error.Message);
            }
        }
    }
}
