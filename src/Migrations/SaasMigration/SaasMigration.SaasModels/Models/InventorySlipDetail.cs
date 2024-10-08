using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bảng chi tiết phiếu kiểm kho
    /// </summary>
    public partial class InventorySlipDetail
    {
        public uint Id { get; set; }
        public int? InventorySlipId { get; set; }
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public int? ProductId { get; set; }
        public string SkuFromVendor { get; set; }
        /// <summary>
        /// Id sản phẩm cha
        /// </summary>
        public int? ParentProductId { get; set; }
        /// <summary>
        /// Mã Sku của hệ thống
        /// </summary>
        public string Sku { get; set; }
        public decimal? QuantityVendorStore { get; set; }
        /// <summary>
        /// Tong tien chenh lech gia kiem kho va ton kho. CT = (Quantity - QuantityVendorStore) * PriceProduct
        /// </summary>
        public decimal? TotalPriceDifference { get; set; }
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Gia bán buôn san pham tai thoi diem kiem kho
        /// </summary>
        public decimal? PriceProduct { get; set; }
        /// <summary>
        /// Tổng số lần cập nhật
        /// </summary>
        public int? NumberUpdate { get; set; }
        /// <summary>
        /// Id bo phan
        /// </summary>
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
        /// Ngày kiểm kho và bằng với Ngày kiểm kho của bàng [_inventory_slip]
        /// </summary>
        public DateOnly? Date { get; set; }
        /// <summary>
        /// Giá vốn sản phẩm khi keiẻm kho
        /// </summary>
        public decimal? CostProduct { get; set; }
        /// <summary>
        /// giá bán lẻ sản phẩm khi kiểm kho
        /// </summary>
        public decimal? PriceRetailProduct { get; set; }
        /// <summary>
        /// tổng chênh theo Cost
        /// </summary>
        public decimal? TotalCostDifference { get; set; }
        /// <summary>
        /// Tổng tiền chênh theo giá bán lẻ
        /// </summary>
        public decimal? TotalPriceRetailDifference { get; set; }
    }
}
