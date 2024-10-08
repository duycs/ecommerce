using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class StatusGroupPivot
    {
        public uint Id { get; set; }
        public int GroupId { get; set; }
        public int StatusId { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string Uid { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
