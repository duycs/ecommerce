using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class FeedBack
    {
        public uint Id { get; set; }
        /// <summary>
        /// Ứng dụng
        /// </summary>
        public string App { get; set; }
        /// <summary>
        /// Nội dung feedback
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Người feedback
        /// </summary>
        public int? UserFeedBackId { get; set; }
        /// <summary>
        /// Version bản ghi
        /// </summary>
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
