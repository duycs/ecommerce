using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Contact
    {
        public uint Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Feedback { get; set; }
        public bool? IsRead { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? Editor { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
