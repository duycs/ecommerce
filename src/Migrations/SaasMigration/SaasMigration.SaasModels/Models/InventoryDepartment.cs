using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Phieu xuat hang cho moi bo phan kho
    /// </summary>
    public partial class InventoryDepartment
    {
        public uint Id { get; set; }
        public string OrderType { get; set; }
        public int? OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateOnly? OrderDate { get; set; }
        public string OrderActionType { get; set; }
        public int? StoreId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        public int? TransporterId { get; set; }
        public int? StaffId { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// So thu tu phieu. Vi du : so thu tu la 3, tren tong so 5 phieu, hien thi ra man hinh la 3/5
        /// </summary>
        public int? RecordOrderItem { get; set; }
        /// <summary>
        /// Tong so phieu xuat, chinh bang tong so bo phan tham gia. Vi du :  tong so phieu xuat la 5.
        /// </summary>
        public int? RecordOrderTotal { get; set; }
        public decimal? TotalQuantity { get; set; }
        public decimal? TotalQuantityOrder { get; set; }
        /// <summary>
        /// Trang thai thieu hang
        /// </summary>
        public ulong? IsDeficient { get; set; }
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
