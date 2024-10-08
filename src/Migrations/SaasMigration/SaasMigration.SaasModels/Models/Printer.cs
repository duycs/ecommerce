using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng quản lý máy in
    /// </summary>
    public partial class Printer
    {
        public uint Id { get; set; }
        public int? StoreId { get; set; }
        /// <summary>
        /// ID tầng
        /// </summary>
        public int? FloorId { get; set; }
        /// <summary>
        /// IP máy in
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// Nhãn máy in
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Mô tả máy in
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Id bộ phận
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// Id nhân viên
        /// </summary>
        public int? StaffId { get; set; }
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
