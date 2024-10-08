using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng thống kê quỹ tiền ( Tài khoản kế toán ) theo ngày
    /// </summary>
    public partial class StatisticAccountingDay
    {
        public uint Id { get; set; }
        /// <summary>
        /// Id tài khoảng kế toán
        /// </summary>
        public int? AccountId { get; set; }
        /// <summary>
        /// Số tiền đầu kỳ
        /// </summary>
        public decimal? PeriodStart { get; set; }
        /// <summary>
        /// Số tiền thu trong kỳ
        /// </summary>
        public decimal? CashBookIn { get; set; }
        /// <summary>
        /// Số tiền chi trong kỳ
        /// </summary>
        public decimal? CashBookOut { get; set; }
        /// <summary>
        /// Số tiền cuối kỳ
        /// </summary>
        public decimal? PeriodEnd { get; set; }
        /// <summary>
        /// Ngày thông kê
        /// </summary>
        public DateOnly? StatisticDate { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
        public int? EditorId { get; set; }
    }
}
