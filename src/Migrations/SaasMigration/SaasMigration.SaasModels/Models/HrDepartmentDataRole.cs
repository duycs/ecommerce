using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class HrDepartmentDataRole
    {
        public uint Id { get; set; }
        public int? DepartmentId { get; set; }
        public string DataType { get; set; }
        public int? DataId { get; set; }
        /// <summary>
        /// Vi tri du lieu duoc gan truc tiep, tranh nham lan voi cap cha hoac con
        /// </summary>
        public bool? Directly { get; set; }
        public string StatusCode { get; set; }
        public int? Editor { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Creator { get; set; }
        public string Uuid { get; set; }
    }
}
