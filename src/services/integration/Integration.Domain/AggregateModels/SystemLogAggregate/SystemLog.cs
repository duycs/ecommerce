using ECommerce.Shared.SeedWork;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration.Domain.AggregateModels.SystemLogAggregate
{
    [Table("system_logs", Schema = "integration")]
    public class SystemLog : DateTrackingEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public int Status { get; private set; }
        public IList<ContentLog> Contents { get; private set; }
        protected SystemLog() { }

        public SystemLog(string name, int status)
        {
            Name = name;
            Status = status;
            Contents = new List<ContentLog>();
        }

        public void AddContentLog(string name, object content)
        {
            Contents.Add(new ContentLog(name, content));
        }

        public void SetStatus(int status)
        {
            Status = status;
        }

    }

    public class ContentLog
    {
        public string Name { get; set; }
        public object Content { get; set; }

        protected ContentLog() { }

        public ContentLog(string name, object content)
        {
            Name = name;
            Content = content;
        }

    }
}
