using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class MoneyToForeignCurrencyAccount
    {
        public int Id { get; set; }
        /// <summary>
        /// Tài khoản kế toán
        /// </summary>
        public int? MoneyAccountId { get; set; }
        /// <summary>
        /// Loại nguồn vào: enum(&apos;account_transfer&apos;, &apos;account_enter&apos;) v.v.v.
        /// </summary>
        public string SourceType { get; set; }
        /// <summary>
        /// Id của nguồn vào
        /// </summary>
        public int? SourceId { get; set; }
        /// <summary>
        /// Thời gian của phiếu nguồn
        /// </summary>
        public DateTime? SourceDate { get; set; }
        /// <summary>
        /// Số tiền được nhận của nguồn vào
        /// </summary>
        public decimal? AmountReceived { get; set; }
        /// <summary>
        /// Tổng số tiền đã chi so với số nhận từ nguồn.  TotalAmountSpent &lt;= AmountReceived
        /// </summary>
        public decimal? TotalAmountSpent { get; set; }
        /// <summary>
        /// Mã tiền tệ
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Tỉ giá ngoại tệ đầu vào so với tiền tệ quốc gia ( TargetCurentcyCode [VND] )
        /// </summary>
        public decimal? ExchangRate { get; set; }
        /// <summary>
        /// Đầu vào của ngoại tệ có tỉ giá hay không
        /// </summary>
        public bool? IsExchangeRate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public int? CreatorId { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
