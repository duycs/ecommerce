using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Bang du lieu ton kho theo ma NCC tai cac cua hang
    /// </summary>
    public partial class ProductVendorStore
    {
        public uint Id { get; set; }
        public int StoreId { get; set; }
        public int ProductParentId { get; set; }
        /// <summary>
        /// Bao gom ProductID va ProductModelId
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// SkuFromVendor + Vendor Code
        /// </summary>
        public string SkuFromVendor { get; set; }
        public string Sku { get; set; }
        public decimal? QuantityInstock { get; set; }
        /// <summary>
        /// So luong duoc tam giu khi ban hang (Tao don hang), chua tru ton kho chinh thuc
        /// </summary>
        public decimal QuantityLock { get; set; }
        public decimal? QuantityInstockStatisticOld { get; set; }
        /// <summary>
        /// Số lượng đầu kiểm kho
        /// </summary>
        public decimal? QuantitySlip { get; set; }
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
