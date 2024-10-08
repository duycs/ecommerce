using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class VendorOrderDetail
    {
        public uint Id { get; set; }
        /// <summary>
        /// ID from _vendor_order
        /// </summary>
        public int VendorOrderId { get; set; }
        public int? ParentProductId { get; set; }
        public int? ProductModelId { get; set; }
        public int? ProductVendorId { get; set; }
        /// <summary>
        /// Input form type
        /// </summary>
        public int? AttributeTemplateId { get; set; }
        public decimal? Cost { get; set; }
        /// <summary>
        /// Import quantity
        /// </summary>
        public decimal? Quantity { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountCash { get; set; }
        /// <summary>
        /// Don vi tien te. Vi du: VND, CNY
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Ty gia. Vi du: 1CNY = 3600 VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        /// <summary>
        /// Trang thai san pham nhap khong nam trong danh sach dat hang NCC
        /// </summary>
        public bool? IsExtraImport { get; set; }
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
