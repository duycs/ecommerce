using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng lưu dữ liệu thuộc tính của sản phẩm cha
    /// </summary>
    public partial class AttributeTemplatePivot
    {
        public uint Id { get; set; }
        public int? ProductId { get; set; }
        public int? TemplateId { get; set; }
        public int? AttributeId { get; set; }
        public string InputType { get; set; }
        public int? Priority { get; set; }
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
