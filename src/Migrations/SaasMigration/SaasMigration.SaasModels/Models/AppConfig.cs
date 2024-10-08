using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class AppConfig
    {
        public int Id { get; set; }
        /// <summary>
        /// Config key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Config value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        public byte? IsSystemConfig { get; set; }
        public int? Priority { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public int? Version { get; set; }
        public byte? IsActivated { get; set; }
        public byte? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
