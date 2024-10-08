using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class MetaDatum
    {
        public uint Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
