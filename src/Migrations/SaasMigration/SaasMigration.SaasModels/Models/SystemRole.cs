using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class SystemRole
    {
        public uint Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int? ModuleId { get; set; }
        public string ControllerType { get; set; }
        public string ActionType { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public string Icon { get; set; }
        public string CssClass { get; set; }
        public bool? IsShowMenu { get; set; }
        public int? Priority { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
