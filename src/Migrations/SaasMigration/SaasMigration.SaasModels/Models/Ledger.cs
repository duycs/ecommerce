using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Ledger
    {
        public uint Id { get; set; }
        /// <summary>
        /// Loai phieu thu hay chi
        /// </summary>
        public string CashFlowType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string BillCode { get; set; }
        /// <summary>
        /// Kieu phieu thu. Vi du: ban buon, ban le, ...
        /// </summary>
        public string BillType { get; set; }
        /// <summary>
        /// ID lien quan. Vd: CustomerId
        /// </summary>
        public int? BillId { get; set; }
        public string RecordOrder { get; set; }
        public int? MoneyAccountId { get; set; }
        public int? ContraAccountId { get; set; }
        public int? StoreId { get; set; }
        /// <summary>
        /// Nhom doi tuong
        /// </summary>
        public string ObjectType { get; set; }
        /// <summary>
        /// ID doi tuong
        /// </summary>
        public int? ObjectId { get; set; }
        public int? StaffId { get; set; }
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        public int? TransporterId { get; set; }
        public decimal? Total { get; set; }
        public DateOnly LedgerDate { get; set; }
        /// <summary>
        /// Trường xác nhận phiếu thu/chi có được đưa vào báo cáo kết quả kinh doanh hay không.
        /// </summary>
        public bool? IsSalesReport { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
