using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models.Locations
{
    public class LocationVersionDto
    {
        public string VersionNumber { get; set; }

        public LocationVersionDto(string versionNumber)
        {
            VersionNumber = versionNumber;
        }
    }
}
