using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class SystemDataRoleFullPermission
    {
        public uint Id { get; set; }
        /// <summary>
        /// Nhom doi tuong duoc thiet lap, vi du: Bo phan, Tai khoan
        /// </summary>
        public string TargetType { get; set; }
        /// <summary>
        /// ID Doi tuong duoc thiet lap, vi du: Bo phan, Tai khoan
        /// </summary>
        public int? TargetId { get; set; }
        public string DataType { get; set; }
        public string StatusCode { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
