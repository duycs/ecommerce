﻿using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class TaxonomyTerm
    {
        public uint Id { get; set; }
        public int TaxonomyId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string Uuid { get; set; }
    }
}
