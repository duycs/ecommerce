using ECommerce.Shared.Configurations;
using ECommerce.Shared.Models;
using ECommerce.Shared.Mvc;
using Identity.Application.Models;
using Identity.Application.Read.Queries;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using ECommerce.Shared.Exceptions;
using Identity.Domain.AccountAggregate;
using Microsoft.AspNetCore.Identity;
using Identity.Application.Write.Handlers;
using ECommerce.Shared.Extensions;

namespace Identity.Api.Controllers.MobileControllers
{
    public class AccountController : MobileControllerBase
    {
        private readonly AuthenticationSettings _settings;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMediator _mediator;
        private readonly UserManager<Account> _userManager;

        public AccountController(IOptionsSnapshot<AuthenticationSettings> settings,
            IHttpClientFactory clientFactory,
            IMediator mediator,
            UserManager<Account> userManager)
        {
            _settings = settings.Value;
            _clientFactory = clientFactory;
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginForm form)
        {
            var user = await _userManager.FindByNameAsync(form.UserName);
            if (user == null)
            {
                throw new BusinessRuleException(ECommerceBusinessRule.NoUserFound);
            }
            if (!await _userManager.CheckPasswordAsync(user, form.Password))
            {
                throw new BusinessRuleException(ECommerceBusinessRule.PasswordInvalid);
            }
            var tokenClient = new TokenClient(_clientFactory.CreateClient(), new TokenClientOptions()
            {
                Address = _settings.Authority + "/connect/token",
                ClientId = "mobile"
            });
            var response = await tokenClient.RequestPasswordTokenAsync(form.UserName, form.Password);
            if (response.IsError)
            {
                return BadRequest(response.Error);
            }
            return Ok(new AccessTokenModel(response.AccessToken, response.ExpiresIn, response.TokenType, response.RefreshToken, response.Scope));
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh(RefreshTokenForm form)
        {
            var tokenClient = new TokenClient(_clientFactory.CreateClient(), new TokenClientOptions()
            {
                Address = _settings.Authority + "/connect/token",
                ClientId = "mobile"
            });
            var response = await tokenClient.RequestRefreshTokenAsync(form.RefreshToken);
            if (response.IsError)
            {
                return BadRequest(new ErrorModel(response.Error, response.ErrorDescription));
            }
            return Ok(new AccessTokenModel(response.AccessToken, response.ExpiresIn, response.TokenType, response.RefreshToken, response.Scope));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(RefreshTokenForm form)
        {
            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.RevokeTokenAsync(new TokenRevocationRequest()
            {
                Address = _settings.Authority + "/connect/revocation",
                ClientId = "mobile",
                TokenTypeHint = "refresh_token",
                Token = form.RefreshToken
            });
            if (response.IsError)
            {
                return BadRequest(new ErrorModel(response.Error, string.Empty));
            }
            return Accepted();
        }

        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordForm form)
        {
            var account = await _userManager.FindByIdAsync(CurrentUserId.ToString());
            if (!await _userManager.CheckPasswordAsync(account, form.CurrentPassword))
            {
                throw new BusinessRuleException(ECommerceBusinessRule.PasswordInvalid);
            }
            await _userManager.ChangePasswordAsync(account, form.CurrentPassword, form.NewPassword);
            return Accepted();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(CreateAccountCommand command)
        {
            await _mediator.Send(command);
            return Accepted();
        }
    }
}
