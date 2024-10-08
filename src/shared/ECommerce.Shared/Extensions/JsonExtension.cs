using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ECommerce.Shared.Extensions
{
    public static class JsonExtension
    {
        public static T TryDeserialize<T>(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return JsonConvert.DeserializeObject<T>(str);
            }

            return default(T);
        }

        public static T TryDeserialize<T>(this string str, JsonSerializerSettings settings)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return JsonConvert.DeserializeObject<T>(str, settings);
            }

            return default(T);
        }

        public static object TryDeserialize(this string str, Type t, JsonSerializerSettings settings = null)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return JsonConvert.DeserializeObject(str, t, settings);
            }

            return null;
        }

        public static Dictionary<string, string> DeserializeDictionaryIgnoreCase(this string str)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            if (string.IsNullOrEmpty(str))
            {
                return dictionary;
            }

            JsonConvert.PopulateObject(str, dictionary);
            return dictionary;
        }
    }
}
