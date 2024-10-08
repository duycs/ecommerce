using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class SystemUserRolePivot
    {
        public uint Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
