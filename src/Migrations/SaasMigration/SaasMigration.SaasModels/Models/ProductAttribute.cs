using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ProductAttribute
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string Slug { get; set; }
        public string Value { get; set; }
        public int? TypeId { get; set; }
        public string TypeCode { get; set; }
        public string Description { get; set; }
        public int? OrderNumber { get; set; }
        /// <summary>
        /// sự ưu tiên
        /// </summary>
        public int? Priority { get; set; }
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
