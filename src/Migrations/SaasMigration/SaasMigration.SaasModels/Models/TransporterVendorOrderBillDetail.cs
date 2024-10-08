using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class TransporterVendorOrderBillDetail
    {
        public uint Id { get; set; }
        public int BillId { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal? Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Total { get; set; }
        /// <summary>
        /// Don vi tien te. Vi du: VND, CNY
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Ty gia. Vi du: 1CNY = 3600 VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        public int? CreatorId { get; set; }
        public int EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
