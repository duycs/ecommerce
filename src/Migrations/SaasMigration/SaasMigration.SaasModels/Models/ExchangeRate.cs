using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ExchangeRate
    {
        public uint Id { get; set; }
        public int? SourceCurrencyId { get; set; }
        public string SourceCurrencyCode { get; set; }
        public int? TargetCurrencyId { get; set; }
        public string TargetCurrencyCode { get; set; }
        public decimal? Exchange { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public bool? Displayable { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
