using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng định nghĩa kiểu thuộc tính. Ví dụ: Size, Màu sắc,...
    /// </summary>
    public partial class Status
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Icon ID
        /// </summary>
        public int? MediaId { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string CssClass { get; set; }
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
