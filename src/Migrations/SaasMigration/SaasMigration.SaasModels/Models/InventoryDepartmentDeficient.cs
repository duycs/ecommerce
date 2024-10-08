using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    /// <summary>
    /// Ghi chu truong hop hang thieu so voi don hang
    /// </summary>
    public partial class InventoryDepartmentDeficient
    {
        public uint Id { get; set; }
        public int? ProductModelId { get; set; }
        public int? ProductVendorId { get; set; }
        public int? OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateOnly? OrderDate { get; set; }
        public string OrderType { get; set; }
        public int? StoreId { get; set; }
        public int? DepartmentId { get; set; }
        /// <summary>
        /// Phieu xuat hang tu bo phan kho. ID tu bang CustomerOrderStoreDepartment
        /// </summary>
        public int? DepartmentBillId { get; set; }
        public decimal? QuantityOrder { get; set; }
        public decimal? QuantityExport { get; set; }
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
