using ECommerce.Shared.SeedWork;

namespace Notification.Domain.Enum
{
    public class NotificationStatus : Enumeration
    {
        public static NotificationStatus UnSeen = new NotificationStatus(1, "UnSeen");
        public static NotificationStatus Seen = new NotificationStatus(2, "Seen");
        public NotificationStatus() : base() { }

        public NotificationStatus(int id, string name) : base(id, name) { }
    }
}
