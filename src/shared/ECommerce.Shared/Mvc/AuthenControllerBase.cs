using AspNet.Security.OpenIdConnect.Primitives;
using ECommerce.Shared.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace ECommerce.Shared.Mvc
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class AuthenControllerBase : ControllerBase
    {
       
        protected Guid CurrentUserId => User.FindFirst(ClaimTypes.NameIdentifier)?.Value?.ToGuid() ?? Guid.Empty;
        protected string CurrentUserRole => User.FindFirst(OpenIdConnectConstants.Claims.Role).Value;
        protected string CurrentUserName => $"{User?.FindFirst(OpenIdConnectConstants.Claims.GivenName)?.Value} {User?.FindFirst(OpenIdConnectConstants.Claims.FamilyName)?.Value}";
    }
}
