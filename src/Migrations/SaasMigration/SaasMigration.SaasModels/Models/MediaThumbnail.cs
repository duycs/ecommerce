using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class MediaThumbnail
    {
        public ulong Id { get; set; }
        public int MediaId { get; set; }
        public int Dimension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
