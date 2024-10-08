using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Notification.Domain.AggregateModels.TemplateAggregate
{
    public static class NotificationTemplateKey
    {
        public const string OrderConfirmed = "order_confirmed";
        public const string OrderShipping = "order_shipping";
        public const string OrderShipped = "order_shipped";
        public const string OrderCanceled = "order_canceled";

        public static IEnumerable<string> Values()
        {
            var fields =
                typeof(NotificationTemplateKey).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(t => t.GetValue(null) as string);
        }

        public static bool HasValue(string key)
        {
            return Values().Contains(key);
        }
    }
}
