using Identity.Domain.AccountAggregate;
using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Identity.Api.Helpers
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ILogger<ResourceOwnerPasswordValidator> _logger;
        private readonly UserManager<Account> _userManager;
        private readonly IEventService _events;
        private readonly SignInManager<Account> _signInManager;

        public ResourceOwnerPasswordValidator(ILogger<ResourceOwnerPasswordValidator> logger,
            UserManager<Account> userManager,
            SignInManager<Account> signInManager,
            IEventService events)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _events = events;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByNameAsync(context.UserName);
            if (user != null)
            {
                if (!user.IsActive)
                {
                    _logger.LogInformation("Authentication failed for username: {username}, reason: inactive", context.UserName);
                    await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "inactive", interactive: false));
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User account is not active");
                    return;
                }
                var result = await _signInManager.CheckPasswordSignInAsync(user, context.Password, true);
                if (result.Succeeded)
                {
                    var sub = await _userManager.GetUserIdAsync(user);

                    _logger.LogInformation("Credentials validated for username: {username}", context.UserName);
                    await _events.RaiseAsync(new UserLoginSuccessEvent(context.UserName, sub, context.UserName, interactive: false));

                    context.Result = new GrantValidationResult(sub, OidcConstants.AuthenticationMethods.Password);
                    return;
                }

                if (result.IsLockedOut)
                {
                    _logger.LogInformation("Authentication failed for username: {username}, reason: locked out", context.UserName);
                    await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "locked out", interactive: false));
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User account locked out.");
                    return;
                }

                if (result.IsNotAllowed)
                {
                    _logger.LogInformation("Authentication failed for username: {username}, reason: not allowed", context.UserName);
                    await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "not allowed", interactive: false));
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User account locked out.");
                    return;
                }

                _logger.LogInformation("Authentication failed for username: {username}, reason: invalid credentials", context.UserName);
                await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "invalid credentials", interactive: false));
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Wrong password");
                return;
            }

            _logger.LogInformation("No user found matching username: {username}", context.UserName);
            await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "invalid username", interactive: false));
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "No user found with this name or email address");
        }
    }
}
