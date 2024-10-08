using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Shared.Mvc
{
    [Route("api/v1/mobile/[controller]")]
    public abstract class MobileControllerBase : AuthenControllerBase
    {
    }
}
