using ECommerce.Shared.Extensions;
using ECommerce.Shared.SeedWork;
using Newtonsoft.Json;
using Notification.Domain.Enum;
using System;

namespace Notification.Application.DtoModels
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public NotificationStatus NotificationStatus => Enumeration.FromValue<NotificationStatus>(Status);
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public string PayloadContents { get; set; }
        public object Payload => !string.IsNullOrEmpty(PayloadContents) ? JsonConvert.DeserializeObject(PayloadContents.ToCamelCase()) : null;
    }
}
