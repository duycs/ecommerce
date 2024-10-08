using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class CustomerOrderDetail
    {
        public uint Id { get; set; }
        public int? CustomerOrderId { get; set; }
        public int? ParentProductId { get; set; }
        public int? ProductModelId { get; set; }
        public string Sku { get; set; }
        public decimal? Cost { get; set; }
        /// <summary>
        /// Gia ban
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Giá bán buôn
        /// </summary>
        public decimal? PriceWholesale { get; set; }
        /// <summary>
        /// Giá bán lẻ
        /// </summary>
        public decimal? PriceRetail { get; set; }
        /// <summary>
        /// Import quantity
        /// </summary>
        public decimal? Quantity { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountCash { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Total { get; set; }
        /// <summary>
        /// Tổng giá vốn bán hàng
        /// </summary>
        public decimal? TotalCost { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
        public int? Version { get; set; }
    }
}
