using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ImportVendor
    {
        public uint Id { get; set; }
        /// <summary>
        /// Id đơn đặt hàng. Reference   bảng _vendor_order_v2
        /// </summary>
        public int? VendorOrderId { get; set; }
        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        public int? VendorId { get; set; }
        /// <summary>
        /// Id nhà vận chuyển
        /// </summary>
        public int? TransporterId { get; set; }
        /// <summary>
        /// Id cửa hàng
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// Mã đơn nhập
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// số thứ tự đơn
        /// </summary>
        public string RecordOrder { get; set; }
        /// <summary>
        /// Tổng số lượng nhập của đơn
        /// </summary>
        public decimal? TotalQuantity { get; set; }
        /// <summary>
        /// CurrencyCode của đơn đặt
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// giá đón quy đổi ra VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        /// <summary>
        /// Ngày giờ  nhập
        /// </summary>
        public DateTime? DateImported { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// &quot;- Trạng thái đơn hàng.
        /// - Trạng thái: 
        /// 1. importing : đang nhập
        /// 2. completed : hoàn thành&quot;
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// Version bản ghi
        /// </summary>
        public int? Version { get; set; }
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
        /// <summary>
        /// không xoá: 0, Xoá: 1
        /// </summary>
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
