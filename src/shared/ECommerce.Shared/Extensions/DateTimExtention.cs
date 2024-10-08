using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Shared.Extensions
{
    public class DateTimExtention
    {
        public static DateTime UnixToTime(int unix)
        {
            var datetime = new DateTime(1970, 1, 1);
            datetime = datetime.AddSeconds(unix);
            return datetime;

        }
    }
}
