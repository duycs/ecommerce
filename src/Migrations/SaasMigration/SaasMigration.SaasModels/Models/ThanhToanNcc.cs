using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class ThanhToanNcc
    {
        public int? TiGia { get; set; }
        public string NgayThang { get; set; }
        public string IdPhieuChi { get; set; }
        public string TenNcc { get; set; }
        public int? TienTrung { get; set; }
        public int? TienViet { get; set; }
    }
}
