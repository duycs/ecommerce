using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Vendor
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        /// <summary>
        /// Công nợ đầu kỳ
        /// </summary>
        public decimal? BeginningLiabilities { get; set; }
        /// <summary>
        /// Cong no hien tai
        /// </summary>
        public decimal Liabilities { get; set; }
        /// <summary>
        /// Công nơ đặt hàng từ nhà cung cấp
        /// </summary>
        public decimal? LiabilitiesOrder { get; set; }
        /// <summary>
        /// Công nợ nhập hàng từ nhà cung cấp
        /// </summary>
        public decimal? LiabilitiesImport { get; set; }
        /// <summary>
        /// Gioi han cong no cho phep
        /// </summary>
        public decimal MaxLiabilities { get; set; }
        /// <summary>
        /// Tổng số lượng sản phẩm đặt hàng
        /// </summary>
        public decimal? TotalQuantityOrdered { get; set; }
        /// <summary>
        /// Tổng số lượng sản phẩm đã nhập hàng
        /// </summary>
        public decimal? TotalQuantityImported { get; set; }
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
        public int? IsMigrate { get; set; }
        public decimal? CnDauKy { get; set; }
    }
}
