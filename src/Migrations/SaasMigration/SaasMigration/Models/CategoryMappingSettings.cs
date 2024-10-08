using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasMigration.Models
{
    public class CategoryMappingSettings
    {
        public string Name { get; set; }
        public uint SaasId { get; set; }
        public IEnumerable<CategoryChildSettings> Children { get; set; }
    }

    public class CategoryChildSettings
    {
        public string Name { get; set; }
        public uint[] Children { get; set; }
    }
}
