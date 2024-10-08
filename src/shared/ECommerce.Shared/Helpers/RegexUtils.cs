using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ECommerce.Shared.Helpers
{
    public static class RegexUtils
    {
        public static readonly Regex SlugRegex = new Regex("(^[a-z0-9])([a-z0-9_-]+)*([a-z0-9])$");

        public static readonly Regex SlugWithSegmentsRegex = new Regex("^(?!-)[a-z0-9_-]+(?<!-)(/(?!-)[a-z0-9_-]+(?<!-))*$");

        public static readonly Regex IpAddressRegex = new Regex("^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

        public static readonly Regex EmailRegex = new Regex("^([a-z0-9_\\.-]+)@([\\da-z\\.-]+)\\.([a-z\\.]{2,6})$");

        public static readonly Regex UrlRegex = new Regex("^(https?:\\/\\/)?([\\da-z\\.-]+)\\.([a-z\\.]{2,6})([\\/\\w \\.-]*)*\\/?$");

        public static readonly Regex PositiveNumberRegex = new Regex("^[1-9]+[0-9]*$");
    }
}
