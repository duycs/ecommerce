using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Video
    {
        public uint Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int? MediaId { get; set; }
        public bool IsPublished { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
