using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Ward
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public int? DistrictId { get; set; }
        public string Uuid { get; set; }
    }
}
