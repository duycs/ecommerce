using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Mvc
{
    [Route("api/v1/[controller]")]
    public abstract class CommonControllerBase : AuthenControllerBase
    {
    }
}
         