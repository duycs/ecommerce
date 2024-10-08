using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class DebtTransfer
    {
        public uint Id { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
        public string SourceObjectType { get; set; }
        public int? SourceObjectId { get; set; }
        public string DestinationObjectType { get; set; }
        public int? DestinationObjectId { get; set; }
        public decimal? Total { get; set; }
        public string BillCode { get; set; }
        public string Note { get; set; }
        /// <summary>
        /// So thu tu bill
        /// </summary>
        public string RecordOrder { get; set; }
    }
}
