using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ImportProductErrorDetail
    {
        public uint Id { get; set; }
        /// <summary>
        /// Id phiếu nhập
        /// </summary>
        public int? ImportProductErrorId { get; set; }
        /// <summary>
        /// Mã phiếu cha
        /// </summary>
        public string ImportProductErrorCode { get; set; }
        /// <summary>
        /// Kho nhập
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// thời gian chuyển
        /// </summary>
        public DateTime? DateTimeImport { get; set; }
        /// <summary>
        /// Id sản phẩm cha
        /// </summary>
        public int? ParentProductId { get; set; }
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public int? ProductId { get; set; }
        /// <summary>
        /// Sku của sản phẩm
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// Số lượng nhập lỗi
        /// </summary>
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Giá vốn bình quân
        /// </summary>
        public decimal? Cost { get; set; }
        /// <summary>
        /// Giá bán buôn
        /// </summary>
        public decimal? PriceWholesale { get; set; }
        /// <summary>
        /// Giá bán lẻ
        /// </summary>
        public decimal? PriceRetail { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Version { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
