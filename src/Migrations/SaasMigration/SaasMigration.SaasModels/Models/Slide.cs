using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Slide
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string LinkText { get; set; }
        public int ImageDesktopId { get; set; }
        public int ImageMobileId { get; set; }
        public bool IsPublished { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
