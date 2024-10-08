using ECommerce.Shared.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Notification.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Services.Services
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _client;
        private readonly ILogger<NotificationService> _logger;
        private readonly OneSignalConfiguration _config;

        public NotificationService(IHttpClientFactory factory, ILogger<NotificationService> logger, IOptionsSnapshot<OneSignalConfiguration> config)
        {
            _logger = logger;
            _config = config.Value;
            _client = factory.CreateClient("OneSignal");
            _client.BaseAddress = new Uri(_config.HostUrl);
        }

        public async Task<bool> Notify(Guid userId, string title, string content)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _config.AppSecret);
            var body = new
            {
                app_id = _config.AppId,
                headings = new
                {
                    en = title
                },
                contents = new
                {
                    en = content
                },
                included_segments = new string[] { "Send notification by TAG" },
                filters = new object[] { new { field = "tag", key = "userId", value = userId.ToString() } }
            };
            var result = await _client.PostAsJsonAsync("/api/v1/notifications", body);
            return result.IsSuccessStatusCode;
        }
    }
}
