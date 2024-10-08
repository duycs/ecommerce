using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class LiabilitiesCategory
    {
        public uint Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Thu hoac Chi
        /// </summary>
        public string Type { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsShowOnWeb { get; set; }
        public int? OrderNumber { get; set; }
        public string Code { get; set; }
        public string Uuid { get; set; }
    }
}
