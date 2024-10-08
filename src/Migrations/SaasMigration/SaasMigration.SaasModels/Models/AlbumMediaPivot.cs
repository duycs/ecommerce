using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class AlbumMediaPivot
    {
        public uint Id { get; set; }
        public int? AlbumId { get; set; }
        public int? MediaId { get; set; }
        public short? Priority { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
    }
}
