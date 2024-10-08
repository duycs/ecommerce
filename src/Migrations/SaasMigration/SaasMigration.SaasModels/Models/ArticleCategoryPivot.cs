using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ArticleCategoryPivot
    {
        public uint Id { get; set; }
        public int? ArticleId { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
    }
}
