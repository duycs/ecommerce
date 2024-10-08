using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class AppsVersion
    {
        public uint Id { get; set; }
        /// <summary>
        /// Key định danh của ứng dụng, ví dụ: pexnic_staff
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// Tên ứng dụng. Ví dụ: App quản lý bán hàng.
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// Kiểu ứng dụng: Android, iOS, WebApp
        /// </summary>
        public string AppType { get; set; }
        public int? Priority { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        /// <summary>
        /// Phiên bản của bản ghi
        /// </summary>
        public int? Version { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
        /// <summary>
        /// Version của ứng dụng
        /// </summary>
        public string AppVersion { get; set; }
        /// <summary>
        /// Mô tả cho phiên bản ứng dụng
        /// </summary>
        public string Description { get; set; }
    }
}
