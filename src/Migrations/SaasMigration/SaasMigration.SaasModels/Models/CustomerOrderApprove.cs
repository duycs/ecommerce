using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Danh sach don hang vuot qua dinh muc cong no can phe duyet
    /// </summary>
    public partial class CustomerOrderApprove
    {
        public uint Id { get; set; }
        public int? StoreId { get; set; }
        public int? OrderId { get; set; }
        public string OrderCode { get; set; }
        /// <summary>
        /// Quan ly
        /// </summary>
        public int? ManagerId { get; set; }
        public int? CustomerId { get; set; }
        /// <summary>
        /// Chi phi don hang: GrandTotal
        /// </summary>
        public decimal? Expenses { get; set; }
        /// <summary>
        /// Tien khach tra
        /// </summary>
        public decimal? TotalPay { get; set; }
        /// <summary>
        /// Cong no hien tai
        /// </summary>
        public decimal? Liabilities { get; set; }
        /// <summary>
        /// Dinh muc cong no hien tai
        /// </summary>
        public decimal? MaxLiabilities { get; set; }
        /// <summary>
        /// Muc cong no du kien
        /// </summary>
        public decimal? ExpectedLiabilities { get; set; }
        public decimal? AllowedLiabilities { get; set; }
        /// <summary>
        /// Cho phep cong them mot muc tang cong no toi da. Vi du: dmcn hien la 50.000.000, cho phep thep 20.000.000
        /// </summary>
        public decimal? MaxLiabilitiesExtra { get; set; }
        /// <summary>
        /// Xac nhan da co phan hoi tu quan ly hay chua
        /// </summary>
        public ulong? IsResponded { get; set; }
        public string StatusCode { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
