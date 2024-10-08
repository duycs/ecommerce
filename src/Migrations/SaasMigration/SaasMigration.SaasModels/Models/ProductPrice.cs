using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ProductPrice
    {
        public uint Id { get; set; }
        public int ProductId { get; set; }
        public int? ProductVendorId { get; set; }
        public int? ParentProductId { get; set; }
        public int? ParentProductVendorId { get; set; }
        public decimal? Cost { get; set; }
        /// <summary>
        /// Giá nhập mới nhất
        /// </summary>
        public decimal? CostLatest { get; set; }
        /// <summary>
        /// Gia ban buon
        /// </summary>
        public decimal? PriceWholesale { get; set; }
        /// <summary>
        /// Gia ban le (Niem yet)
        /// </summary>
        public decimal? PriceRetail { get; set; }
        /// <summary>
        /// Don vi tien te. Vi du: VND, CNY
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Ty gia. Vi du: 1CNY = 3600 VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
        public string OrderCode { get; set; }
    }
}
