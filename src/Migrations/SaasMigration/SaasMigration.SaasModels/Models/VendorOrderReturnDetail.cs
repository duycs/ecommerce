using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class VendorOrderReturnDetail
    {
        public uint Id { get; set; }
        public int? VendorOrderReturnId { get; set; }
        public int? ParentProductId { get; set; }
        public int ProductModelId { get; set; }
        public string Sku { get; set; }
        public string SkuFromVendor { get; set; }
        public decimal? Cost { get; set; }
        /// <summary>
        /// Import quantity
        /// </summary>
        public decimal? Quantity { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountCash { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Total { get; set; }
        public int? VendorId { get; set; }
        /// <summary>
        /// Tỷ giá đón quy đổi ra VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
        public int? Version { get; set; }
    }
}
