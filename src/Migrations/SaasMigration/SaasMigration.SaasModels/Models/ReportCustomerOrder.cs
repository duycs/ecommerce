using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ReportCustomerOrder
    {
        public uint Id { get; set; }
        public int? OrderId { get; set; }
        public int? StoreId { get; set; }
        public int? DepartmentId { get; set; }
        public int? VendorId { get; set; }
        public int ProductModelId { get; set; }
        public int? ProductCategoryId { get; set; }
        public string Sku { get; set; }
        public int? ProductVendorOriginalId { get; set; }
        /// <summary>
        /// Product ID from _product_vendor_pivot
        /// </summary>
        public int? ProductVendorId { get; set; }
        public string SkuFromVendor { get; set; }
        public string SkuVendor { get; set; }
        public decimal? Cost { get; set; }
        /// <summary>
        /// Gia ban
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Import quantity
        /// </summary>
        public decimal? Quantity { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountCash { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Total { get; set; }
        public int? AttributeTemplateId { get; set; }
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
