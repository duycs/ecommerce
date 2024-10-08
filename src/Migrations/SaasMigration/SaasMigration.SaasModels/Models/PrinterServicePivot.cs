using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng mapping Service máy chủ in và Máy in. Một service sẽ được cấu hình sử dụng các máy in nào. Việc này giúp service kéo queue chính xác.
    /// </summary>
    public partial class PrinterServicePivot
    {
        public uint Id { get; set; }
        /// <summary>
        /// ID bộ phận
        /// </summary>
        public int? ServiceId { get; set; }
        /// <summary>
        /// ID máy in
        /// </summary>
        public int? PrinterId { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Máy in mặc định
        /// </summary>
        public bool? IsDefaulted { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        /// <summary>
        /// Thứ tự ưu tiên
        /// </summary>
        public int? Priority { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
