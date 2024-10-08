using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Exceptions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadAsObjectAsync<T>(this HttpContent content)
        {
            var contentResult = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(contentResult);
        }
    }
}
