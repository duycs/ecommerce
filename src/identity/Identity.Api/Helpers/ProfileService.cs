using AspNet.Security.OpenIdConnect.Primitives;
using Identity.Domain.AccountAggregate;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Api.Helpers
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<Account> _userManager;
        private readonly IUserClaimsPrincipalFactory<Account> _claimsFactory;

        public ProfileService(UserManager<Account> userManager, IUserClaimsPrincipalFactory<Account> claimsFactory)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {

            var user = await _userManager.GetUserAsync(context.Subject);

            if (user == null)
            {
                throw new InvalidOperationException("Subject is invalid");
            }
            var principal = await _claimsFactory.CreateAsync(user);

            var reqClaimTypes = context.RequestedClaimTypes.Concat(new[]
            {
                OpenIdConnectConstants.Claims.Role,
            });

            var claims = principal.Claims.Where(c => reqClaimTypes.Contains(c.Type)).ToList();

            claims.AddRange(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtClaimTypes.FamilyName, user.LastName ?? string.Empty),
                new Claim(JwtClaimTypes.GivenName, user.FirstName ?? string.Empty),
            });

            if (!string.IsNullOrEmpty(user.Email))
            {
                claims.Add(new Claim(JwtClaimTypes.Email, user.Email));
            }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}
