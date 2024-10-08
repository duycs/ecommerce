using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class LiabilitiesTimeline
    {
        public uint Id { get; set; }
        public string TargetType { get; set; }
        /// <summary>
        /// Depend on TargetType. Ex: CustomerId, TransporterId, VendorId
        /// </summary>
        public int TargetId { get; set; }
        public int? LedgerId { get; set; }
        /// <summary>
        /// ID Danh muc thu chi
        /// </summary>
        public int? LedgerCategoryId { get; set; }
        /// <summary>
        /// ID Danh muc thu chi
        /// </summary>
        public int? LiabilitiesCategoryId { get; set; }
        /// <summary>
        /// Chi phi
        /// </summary>
        public decimal? Expenses { get; set; }
        /// <summary>
        /// Khach thanh toan
        /// </summary>
        public decimal? TotalPay { get; set; }
        /// <summary>
        /// Cong no hien tai
        /// </summary>
        public decimal? Liabilities { get; set; }
        public string BillType { get; set; }
        public int? BillId { get; set; }
        /// <summary>
        /// Số tiền công nợ tăng
        /// </summary>
        public decimal? AmountIncrease { get; set; }
        /// <summary>
        /// Số tiền tông nợ giảm
        /// </summary>
        public decimal? AmountDecrease { get; set; }
        public string Description { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
        public decimal? TotalDebtTransmitted { get; set; }
        public decimal? TotalDebtReceived { get; set; }
    }
}
