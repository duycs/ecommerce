using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Khu vực của cửa hàng. Ví dụ: Tầng 1, tầng 2, tầng 3; Khu 1, khu 2 , khu 3,...
    /// </summary>
    public partial class StoreArea
    {
        public uint Id { get; set; }
        /// <summary>
        /// Tên khu vực
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Mã nhóm khu vực. Ví dụ: floor, zone,...
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Mô tả khu vực
        /// </summary>
        public string Description { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        /// <summary>
        /// Thứ tự ưu tiên
        /// </summary>
        public int? Priority { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
