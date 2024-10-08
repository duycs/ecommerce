using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Transporter
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// ID quoc gia, mac dinh la Viet Nam
        /// </summary>
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        /// <summary>
        /// Cong no hien tai
        /// </summary>
        public decimal? Liabilities { get; set; }
        /// <summary>
        /// Gioi han cong no cho phep
        /// </summary>
        public decimal? MaxLiabilities { get; set; }
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string Uid { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
