using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class HrDepartment
    {
        public uint Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// TrÃƒÂ¡Ã‚ÂºÃ‚Â¡ng thÃƒÆ’Ã‚Â¡i hoÃƒÂ¡Ã‚ÂºÃ‚Â¡t Ãƒâ€žÃ¢â‚¬ËœÃƒÂ¡Ã‚Â»Ã¢â€žÂ¢ng
        /// </summary>
        public bool? IsActivated { get; set; }
        public string Uid { get; set; }
        public string Uuid { get; set; }
    }
}
