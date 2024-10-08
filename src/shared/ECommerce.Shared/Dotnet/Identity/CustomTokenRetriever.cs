using IdentityModel.AspNetCore.OAuth2Introspection;
using Microsoft.AspNetCore.Http;
using System;

namespace ECommerce.Shared.Dotnet.Identity
{
    public class CustomTokenRetriever
    {
        public static Func<HttpRequest, string> FromHeaderAndQueryString(string headerScheme = "Bearer", string queryScheme = "access_token")
        {
            return delegate (HttpRequest request)
            {
                string text = TokenRetrieval.FromAuthorizationHeader(headerScheme)(request);
                return string.IsNullOrEmpty(text) ? TokenRetrieval.FromQueryString(queryScheme)(request) : text;
            };
        }
    }
}
