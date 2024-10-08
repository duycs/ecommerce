using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class AccountingAccountTransactionHistory
    {
        public int Id { get; set; }
        /// <summary>
        /// ID tài khoản kế toán
        /// </summary>
        public int? AccountId { get; set; }
        /// <summary>
        /// Loại giao dịch: phiếu Thu/Chi, chuyển tiền giữa các tài khoản.
        /// </summary>
        public string TransactionType { get; set; }
        /// <summary>
        /// Id giao dịch: Id phiếu Thu/Chi, Id phiếu chuyển tiền giữa các tài khoản, Id phiếu nhập quỹ.
        /// </summary>
        public int? TransactionId { get; set; }
        /// <summary>
        /// Ngày giao dịch
        /// </summary>
        public DateOnly? TransactionDate { get; set; }
        /// <summary>
        /// Số tiền giao dịch
        /// </summary>
        public decimal? Total { get; set; }
        /// <summary>
        /// Biến động tăng thay giảm
        /// </summary>
        public string ChangeType { get; set; }
        /// <summary>
        /// Số dư có
        /// </summary>
        public decimal? CreditBalance { get; set; }
        /// <summary>
        /// Số dư có
        /// </summary>
        public decimal? OldCreditBalance { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
