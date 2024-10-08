using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class AccountingAccountTransfer
    {
        public uint Id { get; set; }
        /// <summary>
        /// Tài khoản kế toán nhận tiền
        /// </summary>
        public int? TargetAccountId { get; set; }
        /// <summary>
        /// ID tài khoản kế toán (MoneyAccountId) chuyển tiền
        /// </summary>
        public int? SourceAccountId { get; set; }
        /// <summary>
        /// Tổng số tiền chuyển
        /// </summary>
        public decimal? Total { get; set; }
        public DateTime? BillDate { get; set; }
        public string BillCode { get; set; }
        /// <summary>
        /// So thu tu bill
        /// </summary>
        public string RecordOrder { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
