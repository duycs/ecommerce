using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ImportProductError
    {
        public uint Id { get; set; }
        public string ImportProductErrorRecord { get; set; }
        public string ImportProductErrorCode { get; set; }
        /// <summary>
        /// Kho nhập
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// Thời gian chuyển
        /// </summary>
        public DateTime? DateTimeImport { get; set; }
        /// <summary>
        /// Tổng số lượng trong phiếu
        /// </summary>
        public decimal? TotalQuantity { get; set; }
        /// <summary>
        /// Tổng tiền Cost
        /// </summary>
        public decimal? TotalCost { get; set; }
        /// <summary>
        /// Tổng tiền bán buôn
        /// </summary>
        public decimal? TotalPriceWholesale { get; set; }
        /// <summary>
        /// Tổng tiền bán lẻ
        /// </summary>
        public decimal? TotalPriceRetail { get; set; }
        /// <summary>
        /// Ghi chú đơn nhập hàng lỗi
        /// </summary>
        public string Note { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Version { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
