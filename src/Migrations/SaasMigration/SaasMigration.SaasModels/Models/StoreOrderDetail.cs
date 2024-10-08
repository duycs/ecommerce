using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class StoreOrderDetail
    {
        public uint Id { get; set; }
        /// <summary>
        /// ID from _vendor_order
        /// </summary>
        public int StoreOrderId { get; set; }
        public int ProductModelId { get; set; }
        public string Sku { get; set; }
        /// <summary>
        /// Product ID from _product_vendor_pivot
        /// </summary>
        public int? ProductVendorId { get; set; }
        public string SkuVendor { get; set; }
        public decimal? Cost { get; set; }
        /// <summary>
        /// Import quantity
        /// </summary>
        public float Quantity { get; set; }
        public float? DiscountPercent { get; set; }
        public decimal? DiscountCash { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uid { get; set; }
        public string Uuid { get; set; }
    }
}
