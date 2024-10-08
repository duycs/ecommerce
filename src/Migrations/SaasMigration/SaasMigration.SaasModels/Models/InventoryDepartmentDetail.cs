using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class InventoryDepartmentDetail
    {
        public uint Id { get; set; }
        public int? InventoryDepartmentId { get; set; }
        public int? ParentProductId { get; set; }
        public int? ProductModelId { get; set; }
        /// <summary>
        /// Product ID from _product_vendor_pivot
        /// </summary>
        public int? ProductVendorId { get; set; }
        /// <summary>
        /// Import quantity
        /// </summary>
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Import quantity
        /// </summary>
        public decimal? QuantityOrder { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public int? AttributeTemplateId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uid { get; set; }
        public string Uuid { get; set; }
    }
}
