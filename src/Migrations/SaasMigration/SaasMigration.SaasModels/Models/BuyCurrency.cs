using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class BuyCurrency
    {
        public int Id { get; set; }
        /// <summary>
        /// ID tài khoản mua ngoại tệ.
        /// </summary>
        public int? BuyAccountId { get; set; }
        /// <summary>
        /// ID tài khoản ngoại tệ, là tài khoản được nhập số ngoại tệ mua vào.
        /// </summary>
        public int? EnterAccountId { get; set; }
        /// <summary>
        /// Mã ngoại tệ.
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Tỷ giá.
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        /// <summary>
        /// Tổng số tiền bỏ ra mua ngoại tệ.
        /// </summary>
        public decimal? Total { get; set; }
        /// <summary>
        /// Tổng số ngoại tệ mua được.
        /// </summary>
        public decimal? TotalCurrency { get; set; }
        /// <summary>
        /// Mã phiếu mua ngoại tệ.
        /// </summary>
        public string BillCode { get; set; }
        /// <summary>
        /// Ngày mua ngoại tệ.
        /// </summary>
        public DateOnly? BillDate { get; set; }
        /// <summary>
        /// Diễn giải.
        /// </summary>
        public string Description { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
