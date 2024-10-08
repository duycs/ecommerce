using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class PrinterTargetPivot
    {
        public uint Id { get; set; }
        /// <summary>
        /// Nhóm đối tượng sử dụng máy in: bộ phận, nhân viên.
        /// </summary>
        public string TargetType { get; set; }
        /// <summary>
        /// ID bộ phận
        /// </summary>
        public int? TargetId { get; set; }
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
        /// <summary>
        /// Trường xác nhận máy in này sẽ luôn được in.
        /// </summary>
        public bool? IsMaster { get; set; }
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
