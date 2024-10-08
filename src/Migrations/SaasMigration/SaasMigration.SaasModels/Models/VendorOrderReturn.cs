using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class VendorOrderReturn
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int StoreId { get; set; }
        public int? TransporterId { get; set; }
        public string OrderCode { get; set; }
        public DateOnly? OrderDate { get; set; }
        public decimal? TotalQuantity { get; set; }
        /// <summary>
        /// Tam tinh thanh tien tren cac items
        /// </summary>
        public decimal? SubTotal { get; set; }
        /// <summary>
        /// Thanh tien sau khi tinh toan thue, van chuyen, ...
        /// </summary>
        public decimal? GrandTotal { get; set; }
        /// <summary>
        /// Thanh tong tien sau khi tru di discount
        /// </summary>
        public decimal? Total { get; set; }
        public decimal? DiscountCash { get; set; }
        public decimal? DiscountPercent { get; set; }
        /// <summary>
        /// Tien thue
        /// </summary>
        public decimal? Tax { get; set; }
        public string Note { get; set; }
        public string NoteInternal { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// So thu tu bill
        /// </summary>
        public string RecordOrder { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public decimal? Liabilities { get; set; }
        public bool IsDeleted { get; set; }
        public string Uid { get; set; }
        public string Uuid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        /// <summary>
        /// Thời gian xác nhận hoàn tất đơn.
        /// </summary>
        public DateTime? CompletedTime { get; set; }
        public int? EditingId { get; set; }
        public int? VendorOrderNumber { get; set; }
        public int? Version { get; set; }
        /// <summary>
        /// Mã đơn vị tiền tệ.
        /// </summary>
        public string CurrencyCode { get; set; }
    }
}
