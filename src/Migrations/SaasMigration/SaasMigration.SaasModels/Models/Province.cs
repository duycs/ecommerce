using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Province
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? OrderBy { get; set; }
        public string Uuid { get; set; }
    }
}
