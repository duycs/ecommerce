using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Product
    {
        public uint Id { get; set; }
        public int? ParentId { get; set; }
        /// <summary>
        /// Dải size hàng ngang
        /// </summary>
        public int? AttributeFixedId { get; set; }
        /// <summary>
        /// Dải size hàng dọc
        /// </summary>
        public int? AttributeInputId { get; set; }
        public string ParentSku { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string SkuFromVendor { get; set; }
        public string Sku { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        /// <summary>
        /// Gia ban buon
        /// </summary>
        public decimal? PriceWholesale { get; set; }
        /// <summary>
        /// Gia ban le (Niem yet)
        /// </summary>
        public decimal? PriceRetail { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? DiscountCash { get; set; }
        public decimal? DiscountPercent { get; set; }
        /// <summary>
        /// Id from ProductAttribute
        /// </summary>
        public int? UnitId { get; set; }
        /// <summary>
        /// Sự ưu tiên
        /// </summary>
        public int? Priority { get; set; }
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string Uuid { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Images { get; set; }
        public bool IsMigrationItem { get; set; }
    }
}
