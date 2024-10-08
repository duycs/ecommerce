using ECommerce.Shared.Constant;
using ECommerce.Shared.Dotnet;
using ECommerce.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Shared.Mvc
{
    public class ScopeContext : IScopeContext
    {
        public Guid CurrentAccountId { get; private set; }

        public string CurrentAccountName { get; private set; }

        public string CurrentAccountEmail { get; private set; }

        public List<string> AcceptLanguages { get; private set; }

        public Guid ClientId { get; private set; }

        public ScopeContext(IHttpContextAccessor contextAccessor)
        {
            ClaimsPrincipal claimsPrincipal = contextAccessor.HttpContext?.User;
            CurrentAccountId = claimsPrincipal?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value.ToGuid() ?? Guid.Empty;
            ClientId = claimsPrincipal?.FindFirst(CustomClaimTypes.ClientId)?.Value.ToGuid() ?? Guid.Empty;
            CurrentAccountName = claimsPrincipal?.FindFirst("given_name")?.Value + " " + claimsPrincipal?.FindFirst("family_name")?.Value;
            CurrentAccountEmail = claimsPrincipal?.FindFirst("email")?.Value;
            AcceptLanguages = new List<string>();
            string text = contextAccessor.HttpContext?.Request?.Headers["Accept-Language"].ToString();
            if (text != null)
            {
                AcceptLanguages = text.Split(",").ToList();
            }

            string text2 = claimsPrincipal?.FindFirst(CustomClaimTypes.PreferredLanguage)?.Value;
            if (text2 != null)
            {
                System.Enum.TryParse<Locale>(text2, out var result);
                AcceptLanguages.Add(CultureName.FromLocale(result));
            }
        }
    }
}
