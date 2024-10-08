using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class InventoryDetail
    {
        public uint Id { get; set; }
        /// <summary>
        /// ID from _vendor_order
        /// </summary>
        public int InventoryId { get; set; }
        public int? ParentProductId { get; set; }
        public int ProductModelId { get; set; }
        /// <summary>
        /// Product ID from _product_vendor_pivot
        /// </summary>
        public int? ProductVendorId { get; set; }
        public string SkuVendor { get; set; }
        public decimal? Cost { get; set; }
        /// <summary>
        /// Số lượng khi xác nhận nhập kho
        /// </summary>
        public decimal? InitQuantity { get; set; }
        /// <summary>
        /// Import quantity
        /// </summary>
        public decimal? Quantity { get; set; }
        /// <summary>
        /// số lượng nhập bổ sung
        /// </summary>
        public decimal? ExtraQuantity { get; set; }
        /// <summary>
        /// Gia ban
        /// </summary>
        public decimal? Price { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountCash { get; set; }
        public int? AttributeTemplateId { get; set; }
        /// <summary>
        /// Trang thai san pham nhap khong nam trong danh sach dat hang NCC
        /// </summary>
        public bool? IsExtraImport { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uid { get; set; }
        public string Uuid { get; set; }
        /// <summary>
        /// Phiên bản của bản ghi
        /// </summary>
        public int? Version { get; set; }
    }
}
