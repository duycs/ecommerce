using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ImportVendorDetail
    {
        public uint Id { get; set; }
        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        public int? VendorId { get; set; }
        /// <summary>
        /// Id nhập hàng từ nhà cung cấp. Reference bảng _import_product_vendor
        /// </summary>
        public int? ImportVendorId { get; set; }
        /// <summary>
        /// Id đơn đặt hàng. Reference   bảng _vendor_order_v2
        /// </summary>
        public int? VendorOrderId { get; set; }
        /// <summary>
        /// Id nhà vận chuyển
        /// </summary>
        public int? TransporterId { get; set; }
        /// <summary>
        /// Id cửa hàng
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// Id sản phẩm cha
        /// </summary>
        public int? ParentProductId { get; set; }
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public int? ProductId { get; set; }
        /// <summary>
        /// CategoryId của bảng sản phẩm
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// Mã đặt hàng từ nhà cung cấp
        /// </summary>
        public string SkuFromVendor { get; set; }
        /// <summary>
        /// Mã Sku của ProductId
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// Số lượng Nhập
        /// </summary>
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Tiền tệ.  Mã tiền tệ theo quốc gia
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// giá đón quy đổi ra VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        /// <summary>
        /// Thứ tự sắp xếp của AttributeFixed của Peoduct khi nhập hàng. ( để hiển thị đúng thứ tự nhập của người dùng theo AttributeFixedId)
        /// </summary>
        public int? Priority { get; set; }
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
