using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Store
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        /// <summary>
        /// QuÃƒÂ¡Ã‚ÂºÃ‚Â£n lÃƒÆ’Ã‚Â½ kho/cÃƒÂ¡Ã‚Â»Ã‚Â­a hÃƒÆ’Ã‚Â ng
        /// </summary>
        public int? ManagerId { get; set; }
        public string Hotline { get; set; }
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActivated { get; set; }
        public string Uid { get; set; }
        public string Uuid { get; set; }
    }
}
