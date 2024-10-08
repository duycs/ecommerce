using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class District
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public int? ProvinceId { get; set; }
        public string Uuid { get; set; }
    }
}
