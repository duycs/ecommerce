using ECommerce.Shared.Dotnet.Initialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Notification.Domain.AggregateModels.TemplateAggregate;
using Notification.Infrastructure;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Api.Initializations
{
    public class InitNotificationTemplatesStep : IInitializationStep
    {
        public int Order => 2;
        private readonly NotificationDbContext _context;

        public InitNotificationTemplatesStep(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync()
        {
            await AddNotificationTemplate();
            await _context.SaveChangesAsync();
        }

        private async Task AddNotificationTemplate()
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Setup");
            var current = await _context.NotificationTemplates.Select(t => t.Id)
                .ToListAsync();

            var keys = NotificationTemplateKey.Values().ToList();
            var removed = current.Except(keys);

            var list = LoadJson<NotificationRuleTranslationData>(Path.Combine(basePath, "notificationTemplates.json"));

            var added = keys.Except(current).Where(a => list.Any(b => b.Key == a)).Select(k =>
            {
                var newNotiRule = new NotificationTemplate(k);
                var foundNotiRuleContent = list.FirstOrDefault(x => x.Key == k);
                if (foundNotiRuleContent != null && !string.IsNullOrEmpty(foundNotiRuleContent.Content) && !string.IsNullOrEmpty(foundNotiRuleContent.Title))
                {
                    newNotiRule.Update(foundNotiRuleContent.Title, foundNotiRuleContent.Content);
                }
                return newNotiRule;
            });

            var updates = current.Intersect(keys);
            var updated = (await _context.NotificationTemplates.Where(a => updates.Contains(a.Id)).ToListAsync()).Select(a =>
            {
                var foundNotiRuleContent = list.FirstOrDefault(x => x.Key == a.Id);
                if (foundNotiRuleContent != null && !string.IsNullOrEmpty(foundNotiRuleContent.Content) && !string.IsNullOrEmpty(foundNotiRuleContent.Title))
                {
                    a.Update(foundNotiRuleContent.Title, foundNotiRuleContent.Content);
                }
                return a;
            }).ToList();

            _context.NotificationTemplates.AddRange(added);
            _context.NotificationTemplates.RemoveRange(_context.NotificationTemplates.Where(t => removed.Contains(t.Id)));
            _context.NotificationTemplates.UpdateRange(updated);
        }

        private static T[] LoadJson<T>(string path)
        {
            if (TryRead(path, out var text))
            {
                return JsonConvert.DeserializeObject<T[]>(text, new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            }

            return new T[] { };
        }

        private static bool TryRead(string path, out string text)
        {
            text = string.Empty;
            if (!File.Exists(path)) return false;
            text = File.ReadAllText(path);
            return true;
        }
    }

    internal class NotificationRuleTranslationData
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
    }
}
