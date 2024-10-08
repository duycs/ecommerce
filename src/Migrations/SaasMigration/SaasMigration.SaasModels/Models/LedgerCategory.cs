using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class LedgerCategory
    {
        public uint Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Thu hoac Chi
        /// </summary>
        public string Type { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsShowOnWeb { get; set; }
        public int? OrderNumber { get; set; }
        public string Code { get; set; }
        /// <summary>
        /// Trường xác nhận phiếu thu/chi có được đưa vào báo cáo kết quả kinh doanh hay không.
        /// </summary>
        public bool? IsSalesReport { get; set; }
        public bool? IsSystem { get; set; }
        public string Uuid { get; set; }
    }
}
