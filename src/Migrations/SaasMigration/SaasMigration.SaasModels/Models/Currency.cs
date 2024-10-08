using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Currency
    {
        public uint Id { get; set; }
        public string CountryName { get; set; }
        public int? CountryId { get; set; }
        public string IsoCodeAlpha2 { get; set; }
        public string IsoCodeAlpha3 { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyNumber { get; set; }
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
