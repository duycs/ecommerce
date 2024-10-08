using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Attachment
    {
        public uint Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int? FileSize { get; set; }
        public string FileUrl { get; set; }
        public string DownloadToken { get; set; }
        public int? UserId { get; set; }
        public sbyte? UserType { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
