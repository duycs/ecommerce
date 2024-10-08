using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng hàng đợi in
    /// </summary>
    public partial class PrintQueue
    {
        public uint Id { get; set; }
        public string ServiceCode { get; set; }
        public string PrinterName { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        /// <summary>
        /// Trạng thái xác định đã được xử lý
        /// </summary>
        public bool? IsExcuted { get; set; }
        /// <summary>
        /// Trạng thái xác định đã được in
        /// </summary>
        public bool? IsPrinted { get; set; }
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
