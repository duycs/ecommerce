using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Inventory
    {
        public uint Id { get; set; }
        public int? TransporterId { get; set; }
        public int? ImportVendorId { get; set; }
        public int? ExportVendorId { get; set; }
        public int? ImportStoreId { get; set; }
        public int? ExportStoreId { get; set; }
        public decimal? TotalQuantity { get; set; }
        public string BillCode { get; set; }
        public DateOnly? BillDate { get; set; }
        public string BillType { get; set; }
        /// <summary>
        /// Source groups. Ex: vendor, store. Import/export from vendor, store, ...
        /// </summary>
        public string BillGroup { get; set; }
        /// <summary>
        /// Source bill Id. ex: VendorOrderId, StoreOrderId,...
        /// </summary>
        public int? RelatedBillId { get; set; }
        public string StatusCode { get; set; }
        public string Note { get; set; }
        /// <summary>
        /// So thu tu bill
        /// </summary>
        public string RecordOrder { get; set; }
        public int? CreatorId { get; set; }
        public int? Editord { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActivated { get; set; }
        public string Uid { get; set; }
        public string Uuid { get; set; }
        public int? Version { get; set; }
    }
}
