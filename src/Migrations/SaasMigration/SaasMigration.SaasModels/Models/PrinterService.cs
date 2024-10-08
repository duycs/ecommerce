using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng quản lý service máy chủ in
    /// </summary>
    public partial class PrinterService
    {
        public uint Id { get; set; }
        /// <summary>
        /// Nhãn máy in
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Mã máy in
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// IP máy in
        /// </summary>
        public string Ip { get; set; }
        public int? StoreId { get; set; }
        /// <summary>
        /// Mô tả máy in
        /// </summary>
        public string Description { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public int? Priority { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
