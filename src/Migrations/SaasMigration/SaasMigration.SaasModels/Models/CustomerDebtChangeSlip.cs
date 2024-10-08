using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class CustomerDebtChangeSlip
    {
        public uint Id { get; set; }
        public string RecordOrder { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public string DebtChangeCode { get; set; }
        /// <summary>
        /// gioi han cong no cu
        /// </summary>
        public decimal? DebtMaxOld { get; set; }
        /// <summary>
        /// gioi han cong no moi
        /// </summary>
        public decimal? DebtMaxNew { get; set; }
        public string Notes { get; set; }
        /// <summary>
        /// Id khách hàng
        /// </summary>
        public int? CustomerId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
