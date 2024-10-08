using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Chi tiết đặt hàng từ nhà cung cấp version2
    /// </summary>
    public partial class VendorOrderDetailV2
    {
        public uint Id { get; set; }
        /// <summary>
        /// Id đơn đặt hàng. Reference bảng _vendor_order_v2
        /// </summary>
        public int? VendorOrderId { get; set; }
        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        public int? VendorId { get; set; }
        /// <summary>
        /// Mã Order của đơn đặt hàng
        /// </summary>
        public string VendorOrderCode { get; set; }
        /// <summary>
        /// Id nhà vận chuyển
        /// </summary>
        public int? TransporterId { get; set; }
        /// <summary>
        /// Id cửa hàng
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// Ngày giờ đặt hàng
        /// </summary>
        public DateTime? VendorOrderDate { get; set; }
        /// <summary>
        /// Trạng thái đơn đặt:
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// &quot;- Tình trạng Mã hàng:
        /// 1. Chưa nhập: waiting_import
        /// 2. Thiếu hàng: quantity_missing
        /// 3. Đủ hàng: quantity_completed
        /// 4. Thừa hàng: quantity_more&quot;
        /// </summary>
        public string StateCode { get; set; }
        /// <summary>
        /// Sản phẩm cha đặt NCC ( Null khi sản phẩm chưa tồn tại)
        /// </summary>
        public int? ParentProductId { get; set; }
        /// <summary>
        /// Mã sản phẩm đặt hàng từ nhà cung cấp
        /// </summary>
        public string SkuFromVendor { get; set; }
        /// <summary>
        /// Số lượng đặt
        /// </summary>
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Số lượng đặt lần đầu
        /// </summary>
        public decimal? QuantityInit { get; set; }
        /// <summary>
        /// Số lượng đã nhập
        /// </summary>
        public decimal? QuantityImported { get; set; }
        /// <summary>
        /// Giá nhập
        /// </summary>
        public decimal? Cost { get; set; }
        /// <summary>
        /// Giá bán buôn
        /// </summary>
        public decimal? PriceWholesale { get; set; }
        /// <summary>
        /// Giá bản lẻ của sản phẩm
        /// </summary>
        public decimal? PriceRetail { get; set; }
        /// <summary>
        /// - Tổng tiền của sản phẩm.
        /// </summary>
        public decimal? SubTotal { get; set; }
        /// <summary>
        /// Tổng số tiền đã nhập
        /// </summary>
        public decimal? SubTotalImported { get; set; }
        /// <summary>
        /// Tiền tệ.  Mã tiền tệ theo quốc gia
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// giá đón quy đổi ra VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        /// <summary>
        /// Trạng thái sản phẩm không nằm trong Danh sách đặt hàng ban đầu mà được Thêm khi sửa đơn đặt
        /// </summary>
        public bool? IsExtraImport { get; set; }
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
