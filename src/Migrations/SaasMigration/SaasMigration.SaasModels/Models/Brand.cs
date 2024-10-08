using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Brand
    {
        public uint Id { get; set; }
        /// <summary>
        /// Ma thuong hieu
        /// </summary>
        public string Code { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int? AvatarId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public int? OrderNumber { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
