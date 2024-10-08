using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ClearingDebt
    {
        public uint Id { get; set; }
        /// <summary>
        /// Đối tượng: enum(&apos;vendor&apos;)
        /// </summary>
        public string TargetType { get; set; }
        /// <summary>
        /// ID của đối tượng cần truy vấn (VendorId: 1)
        /// </summary>
        public int? TargetId { get; set; }
        /// <summary>
        /// Tài khoản kế toán
        /// </summary>
        public int? MoneyAccountId { get; set; }
        /// <summary>
        /// Số tiền thanh toán
        /// </summary>
        public decimal? PaymentAmount { get; set; }
        /// <summary>
        /// Tiền tệ.  Mã tiền tệ
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Số dự nợ TRƯỚC khi thanh toán của tài khoản thanh toán
        /// </summary>
        public decimal? CreditBalanceBeforePayment { get; set; }
        /// <summary>
        /// Số dự nợ SAU khi thanh toán của tài khoản thanh toán
        /// </summary>
        public decimal? CreditBalanceAfterPayment { get; set; }
        /// <summary>
        /// Công nợ TargetId trước khi thanh toán
        /// </summary>
        public decimal? LiabilitiesBefore { get; set; }
        /// <summary>
        /// Công nợ TargetId sau khi thanh toán
        /// </summary>
        public decimal? LiabilitiesAfter { get; set; }
        /// <summary>
        /// Tổng số tiền thanh toán theo quốc gia theo TargetCurrenyCode( Ví dụ: Việt Nam là VND)
        /// </summary>
        public decimal? TotalAmountPayment { get; set; }
        /// <summary>
        /// Tổng số tiền thanh toán dự kiến theo quốc gia theo TargetCurrenyCode( Ví dụ: Việt Nam là VND)
        /// </summary>
        public decimal? TotalAmountExpectedPayment { get; set; }
        /// <summary>
        /// DiffirenceAmount = TotalAmountPayment - TotalAmountExpectedPayment ( tổng tiền chênh khi thanh toán)
        /// </summary>
        public decimal? DiffirenceAmount { get; set; }
        /// <summary>
        /// Mô tả (diễn giải)
        /// </summary>
        public string Description { get; set; }
        public string RecordOrder { get; set; }
        public string BillCode { get; set; }
        /// <summary>
        /// Chi tiết thanh toán cho các Đơn hàng ( đặt, nhập....)
        /// </summary>
        public string DetailPaymentBill { get; set; }
        /// <summary>
        /// Chi tiết thanh toán tiền từ các nguồn vào tài khoản thanh toán
        /// </summary>
        public string DetailPaymentAmout { get; set; }
        public int? Version { get; set; }
        /// <summary>
        /// ngày tạo bill
        /// </summary>
        public DateTime? DateBill { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
