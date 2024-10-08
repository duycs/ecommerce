using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class StoreOrder
    {
        public uint Id { get; set; }
        public int ImportStoreId { get; set; }
        public int? TransporterId { get; set; }
        public int ExportStoreId { get; set; }
        public string OrderCode { get; set; }
        public DateOnly? OrderDate { get; set; }
        public string Note { get; set; }
        public string StatusCode { get; set; }
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
