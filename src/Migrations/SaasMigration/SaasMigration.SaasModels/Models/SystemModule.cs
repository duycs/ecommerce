using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class SystemModule
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
