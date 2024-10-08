using ECommerce.Shared.SeedWork;

namespace Integration.Domain.Enums
{
    public class StatusLog : Enumeration
    {
        public static StatusLog Successed = new StatusLog(1, "Successed");
        public static StatusLog Failed = new StatusLog(2, "Failed");

        public StatusLog() : base() { }
        public StatusLog(int id, string name) : base(id, name) { }
    }
}
