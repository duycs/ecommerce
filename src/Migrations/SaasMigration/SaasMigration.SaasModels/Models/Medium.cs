using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Medium
    {
        public uint Id { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }
        public float Size { get; set; }
        public string Url { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
