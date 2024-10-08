using ECommerce.Shared.Extensions;
using System.Text;
using System.Text.RegularExpressions;

namespace ECommerce.Shared.Dotnet.SQLBuilder
{
    public static class NpgsqlBuilder
    {
        public static string Order(string alias, string[] sorts, string fallback)
        {
            if (sorts == null || sorts.Length == 0)
            {
                return Order(alias, fallback);
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < sorts.Length; i++)
            {
                string text = Regex.Replace(sorts[i], "-|\\+", "");
                if (!string.IsNullOrWhiteSpace(text))
                {
                    text = text.ToSnakeCasing();
                    stringBuilder.Append(string.IsNullOrEmpty(alias) ? ("\"" + text + "\"") : (" \"" + alias + "\".\"" + Regex.Replace(text, "-|\\+", "") + "\""));
                    stringBuilder.Append(sorts[i].StartsWith("-") ? " DESC" : " ASC");
                    if (i < sorts.Length - 1)
                    {
                        stringBuilder.Append(",");
                    }
                }
            }

            string text2 = stringBuilder.ToString();
            if (!string.IsNullOrWhiteSpace(text2))
            {
                return text2;
            }

            return Order(alias, fallback);
        }

        public static string Order(string alias, params string[] sorts)
        {
            if (sorts == null || sorts.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < sorts.Length; i++)
            {
                string source = Regex.Replace(sorts[i], "-|\\+", "");
                source = source.ToSnakeCasing();
                stringBuilder.Append(string.IsNullOrEmpty(alias) ? ("\"" + source + "\"") : (" \"" + alias + "\".\"" + Regex.Replace(source, "-|\\+", "") + "\""));
                stringBuilder.Append(sorts[i].StartsWith("-") ? " DESC" : " ASC");
                if (i < sorts.Length - 1)
                {
                    stringBuilder.Append(",");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
