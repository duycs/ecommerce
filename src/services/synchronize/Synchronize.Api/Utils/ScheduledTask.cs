using System;

namespace Synchronize.Api.Utils
{
    public class ScheduledTask
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string CronExpression { get; set; }
        public DateTime? LastExecution { get; set; }
        public DateTime? NextExecution { get; set; }
        public string Message { get; set; }
    }
}
