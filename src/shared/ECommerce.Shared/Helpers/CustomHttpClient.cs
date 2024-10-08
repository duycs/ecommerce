using ECommerce.Shared.Configurations;
using ECommerce.Shared.Constant;
using ECommerce.Shared.Exceptions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Shared.Helpers
{
    public class CustomHttpClient
    {
        private readonly SaasConfiguration _config;
        private readonly HttpClient _client;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CustomHttpClient> _logger;
        private string _tokenType;
        private string _token;

        public CustomHttpClient(IHttpClientFactory factory, IOptionsSnapshot<SaasConfiguration> config, IMemoryCache cache, ILogger<CustomHttpClient> logger)
        {
            _config = config.Value;
            _client = factory.CreateClient("Saas");
            _client.BaseAddress = new Uri(_config.Url);
            _cache = cache;
            _logger = logger;
            (_tokenType, _token) = TryGetToken();
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string requestUri, T content, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(_token) || string.IsNullOrEmpty(_tokenType))
            {
                (_tokenType, _token) = await TryLogin();
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType, _token);
            var result = await _client.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json"), cancellationToken);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                (_tokenType, _token) = await TryLogin();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType, _token);
                return await _client.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json"), cancellationToken);
            }
            else
            {
                return result;
            }
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string requestUri, T content, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(_token) || string.IsNullOrEmpty(_tokenType))
            {
                (_tokenType, _token) = await TryLogin();
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType, _token);
            var result = await _client.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json"), cancellationToken);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                (_tokenType, _token) = await TryLogin();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType, _token);
                return await _client.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json"), cancellationToken);
            }
            else
            {
                return result;
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync<T>(string requestUri, T content, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(_token) || string.IsNullOrEmpty(_tokenType))
            {
                (_tokenType, _token) = await TryLogin();
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType, _token);
            var result = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json")
            }, cancellationToken);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                (_tokenType, _token) = await TryLogin();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType, _token);
                return await _client.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json")
                }, cancellationToken);
            }
            else
            {
                return result;
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(_token) || string.IsNullOrEmpty(_tokenType))
            {
                (_tokenType, _token) = await TryLogin();
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType, _token);
            var result = await _client.GetAsync(requestUri, cancellationToken);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                (_tokenType, _token) = await TryLogin();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType, _token);
                return await _client.GetAsync(requestUri, cancellationToken);
            }
            else
            {
                return result;
            }
        }

        private async Task<(string, string)> TryLogin()
        {
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                userName = _config.UserName,
                password = _config.Password
            }), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(UrlsConfig.SaasMethods.Login(), content);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsObjectAsync<LoginResponse>();
            if (!string.IsNullOrEmpty(body.AccessToken) && !string.IsNullOrEmpty(body.TokenType))
            {
                _cache.Set(SaasKey.Token, body.AccessToken);
                _cache.Set(SaasKey.TokenType, body.TokenType);
            }
            return TryGetToken();
        }

        private (string, string) TryGetToken()
        {
            _cache.TryGetValue(SaasKey.Token, out string token);
            _cache.TryGetValue(SaasKey.TokenType, out string tokenType);
            return (tokenType, token);
        }
    }
}
