using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class AccountingAccountEnter
    {
        public int Id { get; set; }
        /// <summary>
        /// ID tài khoản nhập quỹ hoặc rút quỹ.
        /// </summary>
        public int? AccountId { get; set; }
        /// <summary>
        /// Hành động: Nhập quỹ hoặc Rút quỹ.
        /// </summary>
        public string EnterType { get; set; }
        /// <summary>
        /// Tổng số tiền.
        /// </summary>
        public decimal? Total { get; set; }
        /// <summary>
        /// Nguồn tạo phiếu nhập quỹ( nếu có)
        /// </summary>
        public string SourceType { get; set; }
        /// <summary>
        /// Id nguồn
        /// </summary>
        public int? SourceId { get; set; }
        /// <summary>
        /// Mã phiếu.
        /// </summary>
        public string BillCode { get; set; }
        /// <summary>
        /// Ngày lập phiếu.
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
