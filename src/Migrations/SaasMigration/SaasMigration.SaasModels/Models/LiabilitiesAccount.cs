using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Quyet toan cong no: nha cung cap, nha van chuyen
    /// </summary>
    public partial class LiabilitiesAccount
    {
        public uint Id { get; set; }
        public string TargetType { get; set; }
        /// <summary>
        /// Depend on TargetType. Ex: CustomerId, TransporterId, VendorId
        /// </summary>
        public int TargetId { get; set; }
        /// <summary>
        /// Khach thanh toan
        /// </summary>
        public decimal? TotalPay { get; set; }
        /// <summary>
        /// Tien chuyen sang VND
        /// </summary>
        public decimal? TotalPayTransfer { get; set; }
        /// <summary>
        /// Tai khoan ke toan
        /// </summary>
        public int AccountingAccountId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? ExchangeRate { get; set; }
        /// <summary>
        /// ID phieu chi
        /// </summary>
        public int LedgerId { get; set; }
        public DateOnly BillDate { get; set; }
        public string Description { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
