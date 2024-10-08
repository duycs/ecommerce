using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Mvc
{
    public class ValidateMultipartContentAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.IsMultipartContentType())
            {
                context.Result = new StatusCodeResult(415);
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
