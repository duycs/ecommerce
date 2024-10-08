using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ProductPriceBillDetail
    {
        public uint Id { get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public decimal? OldCost { get; set; }
        public decimal? OldPriceWholesale { get; set; }
        public decimal? OldPriceRetail { get; set; }
        public decimal? Cost { get; set; }
        public decimal? PriceWholesale { get; set; }
        public decimal? PriceRetail { get; set; }
        public decimal? IncreaseWholesale { get; set; }
        public decimal? IncreaseRetail { get; set; }
        public decimal? DecreaseWholesale { get; set; }
        public decimal? DecreaseRetail { get; set; }
        /// <summary>
        /// Ty gia. Vi du: 1CNY = 3600 VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        /// <summary>
        /// Don vi tien te. Vi du: VND, CNY
        /// </summary>
        public string CurrencyCode { get; set; }
        public int? CreatorId { get; set; }
        public int EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
