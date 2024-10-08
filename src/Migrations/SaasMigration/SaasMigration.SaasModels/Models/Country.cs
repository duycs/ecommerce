using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Country
    {
        public uint Id { get; set; }
        public string CountryName { get; set; }
        public string CountryVn { get; set; }
        public string CountryCode { get; set; }
        public string IsoCodes { get; set; }
        public string IsoCodeAlpha2 { get; set; }
        public string IsoCodeAlpha3 { get; set; }
        public string FlagIcon { get; set; }
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
