using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class TemplateTable
    {
        public uint Id { get; set; }
        public int? Priority { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Version { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
