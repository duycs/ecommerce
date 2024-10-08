using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class LiabilitiesTimelineVendorOrder
    {
        public uint Id { get; set; }
        /// <summary>
        /// Đối tượng tham chiếu
        /// </summary>
        public string TargetType { get; set; }
        /// <summary>
        /// ID của đối tượng cần truy vấn VendorId: 1
        /// </summary>
        public int? TargetId { get; set; }
        /// <summary>
        /// Kiểu hoá đơn/phiếu. Giá trị enum(&apos;vendor_order&apos;, &apos;import_vendor_order&apos;)
        /// </summary>
        public string BillType { get; set; }
        /// <summary>
        /// ID của kiểu hoá đơn/phiếu
        /// </summary>
        public int? BillId { get; set; }
        /// <summary>
        /// Mô tả (diễn giải)
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Công nợ trước khi update
        /// </summary>
        public decimal? LiabilitiesBefore { get; set; }
        /// <summary>
        /// Số tiền tăng
        /// </summary>
        public decimal? Increase { get; set; }
        /// <summary>
        /// Số tiền giảm
        /// </summary>
        public decimal? Decrease { get; set; }
        /// <summary>
        /// Số tiền công nợ sau khi tăng hoặc giảm
        /// </summary>
        public decimal? LiabilitiesAfter { get; set; }
        /// <summary>
        /// Chức năng
        /// </summary>
        public string Function { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string Uuid { get; set; }
    }
}
