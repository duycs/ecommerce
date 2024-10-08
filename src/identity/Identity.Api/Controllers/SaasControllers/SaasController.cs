using ECommerce.Shared.Configurations;
using Identity.Application.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace Identity.Api.Controllers.SaasControllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SaasController : ControllerBase
    {
        private readonly AuthenticationSettings _settings;
        private readonly IHttpClientFactory _clientFactory;

        public SaasController(IOptionsSnapshot<AuthenticationSettings> settings,
            IHttpClientFactory clientFactory)
        {
            _settings = settings.Value;
            _clientFactory = clientFactory;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(ClientLoginForm form)
        {
            var client = _clientFactory.CreateClient();
            var disco = await client.GetDiscoveryDocumentAsync(_settings.Authority);
            if (disco.IsError)
            {
                throw new System.Exception();
            }
            var clientRequest = new ClientCredentialsTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = form.ClientId,
                ClientSecret = form.ClientSecret
            };
            var response = await client.RequestClientCredentialsTokenAsync(clientRequest);
            if (response.IsError)
            {
                return BadRequest(response.Error);
            }
            return Ok(new AccessTokenModel(response.AccessToken, response.ExpiresIn, response.TokenType, response.RefreshToken, response.Scope));
        }
    }
}
