using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Locations
{
    public class ProvinceDto : BaseLocationDto
    {
        public IEnumerable<DistrictDto> Districts { get; set; }
    }

    public class DistrictDto : BaseLocationDto
    {
        public IList<BaseLocationDto> Wards { get; set; }
    }
}
