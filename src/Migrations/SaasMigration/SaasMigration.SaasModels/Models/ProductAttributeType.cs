using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng định nghĩa kiểu thuộc tính. Ví dụ: Size, Màu sắc,...
    /// </summary>
    public partial class ProductAttributeType
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Icon ID
        /// </summary>
        public int? MediaId { get; set; }
        public int? OrderNumber { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string Uid { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
