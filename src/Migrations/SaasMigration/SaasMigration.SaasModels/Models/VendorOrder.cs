using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class VendorOrder
    {
        public uint Id { get; set; }
        public int VendorId { get; set; }
        public int TransporterId { get; set; }
        public int StoreId { get; set; }
        /// <summary>
        /// Chinh thuc, tra hang, doi hang
        /// </summary>
        public string OrderTransactionType { get; set; }
        public string OrderCode { get; set; }
        public string OrderStatusCode { get; set; }
        public DateOnly? OrderDate { get; set; }
        public string Note { get; set; }
        public string NoteInternal { get; set; }
        /// <summary>
        /// Input form type
        /// </summary>
        public int? AttributeTemplateId { get; set; }
        /// <summary>
        /// Dong tien su dung
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Ty gia. Vi du: 1CNY = 3600 VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        public decimal? TotalQuantity { get; set; }
        /// <summary>
        /// Tam tinh thanh tien tren cac items
        /// </summary>
        public decimal? SubTotal { get; set; }
        /// <summary>
        /// Thanh tong tien sau khi tru di discount
        /// </summary>
        public decimal? Total { get; set; }
        /// <summary>
        /// Thanh tien sau khi tinh toan thue, van chuyen, ...
        /// </summary>
        public decimal? GrandTotal { get; set; }
        public decimal? DiscountCash { get; set; }
        public decimal? DiscountPercent { get; set; }
        /// <summary>
        /// Tien thue
        /// </summary>
        public decimal? Tax { get; set; }
        /// <summary>
        /// Phi van chuyen
        /// </summary>
        public decimal? TransportFee { get; set; }
        /// <summary>
        /// So thu tu bill
        /// </summary>
        public string RecordOrder { get; set; }
        public int? CreatorId { get; set; }
        public int? Editord { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActivated { get; set; }
        public string Uid { get; set; }
        public string Uuid { get; set; }
    }
}
