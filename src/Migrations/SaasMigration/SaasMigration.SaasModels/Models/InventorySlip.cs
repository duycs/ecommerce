using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class InventorySlip
    {
        public uint Id { get; set; }
        public string RecordOrder { get; set; }
        /// <summary>
        /// Mã phiếu kiểm kho
        /// </summary>
        public string InventorySlipCode { get; set; }
        /// <summary>
        /// Tong So luong ton kho truoc khi ghi nhan kiem kho
        /// </summary>
        public decimal? TotalQuantityVendor { get; set; }
        /// <summary>
        /// Tong so luong chenh lech gia kiem kho va ton kho truoc khi kiem. TotalQuantity - TotalQuantityVendor
        /// </summary>
        public decimal? TotalQuantityDefference { get; set; }
        /// <summary>
        /// Tong So luong ton kho truoc khi ghi nhan kiem kho
        /// </summary>
        public decimal? TotalQuantityVendorStore { get; set; }
        /// <summary>
        /// Tổng tiền chênh lệch cua kiểm kho va ton kho theo gia bán buôn. Tinh theo tổng từ dưới lên
        /// </summary>
        public decimal? TotalPriceDifference { get; set; }
        /// <summary>
        /// Ngày kiểm kho
        /// </summary>
        public DateOnly? Date { get; set; }
        /// <summary>
        /// Tong so luong san pham cua phieu kiem kho
        /// </summary>
        public decimal? TotalQuantity { get; set; }
        public int? DepartmentId { get; set; }
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
        /// <summary>
        /// Id cửa hàng
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// Tổng tiền chênh theo gia bán lẻ
        /// </summary>
        public decimal? TotalPriceRetailDifference { get; set; }
        /// <summary>
        /// Tổng tiền chênh của kiểm kho so với tồn theo Cost
        /// </summary>
        public decimal? TotalCostDifference { get; set; }
    }
}
