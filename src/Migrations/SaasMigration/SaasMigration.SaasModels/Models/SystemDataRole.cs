using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class SystemDataRole
    {
        public uint Id { get; set; }
        public int DataId { get; set; }
        public string DataType { get; set; }
        public int? AccountId { get; set; }
        public int? AccountGroupId { get; set; }
        public string StatusCode { get; set; }
        public int? Editor { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public int? Creator { get; set; }
        public string Uuid { get; set; }
    }
}
