using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng cấu hình nhóm thuộc tính. Vd: Giày gồm Size, Màu sắc
    /// </summary>
    public partial class StatusGroup
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string Uid { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsDefaulted { get; set; }
        public string Uuid { get; set; }
    }
}
