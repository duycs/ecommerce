using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class TransporterPriceBill
    {
        public uint Id { get; set; }
        /// <summary>
        /// ID nha van chuyen
        /// </summary>
        public int TransporterId { get; set; }
        /// <summary>
        /// Don vi tien te. Vi du: VND, CNY
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Ty gia. Vi du: 1CNY = 3600 VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        public DateTime? BillDate { get; set; }
        public string BillCode { get; set; }
        /// <summary>
        /// So thu tu bill
        /// </summary>
        public string RecordOrder { get; set; }
        public string Note { get; set; }
        /// <summary>
        /// Tuong tac thu cong hay tu dong
        /// </summary>
        public string ReactiveType { get; set; }
        public int? CreatorId { get; set; }
        public int EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
