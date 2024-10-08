using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ProductMediaPivot
    {
        public uint Id { get; set; }
        public int ProductId { get; set; }
        public int MediaId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string Uid { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
