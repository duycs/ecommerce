using ECommerce.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ECommerce.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string s1)
        {
            // return Regex.Replace(s1,).ToLower();
            return Regex.Replace(s1, "_[a-z]", delegate (Match m)
            {
                return m.ToString().TrimStart('_').ToUpper();
            });
        }
        private static readonly Regex TagsExpression = new Regex("</?.+?>", RegexOptions.Compiled);

        public static string Duplicate(this string str)
        {
            return $"{str}-({DateTimeOffset.Now.ToUnixTimeSeconds()}-1)";
        }

        public static string WithFallback(this string str, string fallback)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str;
            }

            return fallback;
        }

        public static string DuplicateWithCopyTitle(this string str)
        {
            return "Copies of " + str;
        }

        public static string ToFriendlyFileName(this string fileName)
        {
            string? fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            return string.Concat(str1: Path.GetExtension(fileName), str0: fileNameWithoutExtension.ToSlug());
        }

        public static string ToUniqueFileName(this string fileName, bool removeOldName = false)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            if (removeOldName)
            {
                return $"{Guid.NewGuid()}{extension}";
            }

            return $"{fileNameWithoutExtension}-{Guid.NewGuid()}{extension}";
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !value.IsNullOrEmpty();
        }

        public static string ToTsQueryFormat(this string value)
        {
            return new Regex("\\s+").Replace(value.Trim(), "&") ?? "";
        }

        public static string ToTsQueryWithPrefix(this string value, string prefix)
        {
            Regex regex = new Regex("\\s+");
            return prefix + regex.Replace(value.Trim(), "&" + prefix);
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static string NullIfEmpty(this string value)
        {
            if (value == string.Empty)
            {
                return null;
            }

            return value;
        }

        public static string ToSlug(this string value, int? maxLength = null)
        {
            Ensure.Argument.NotNull(value, "value");
            if (RegexUtils.SlugRegex.IsMatch(value))
            {
                return value;
            }

            return GenerateSlug(value, maxLength);
        }

        public static string ToSlugWithSegments(this string value)
        {
            Ensure.Argument.NotNull(value, "value");
            return value.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(string.Empty, (string slug, string segment) => slug = slug + "/" + segment.ToSlug()).Trim('/');
        }

        public static string ToCamelCasing(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        public static string SeparatePascalCase(this string value)
        {
            Ensure.Argument.NotNullOrEmpty(value, "value");
            return Regex.Replace(value, "([A-Z])", " $1").Trim();
        }

        public static string ToSnakeCasing(this string source)
        {
            source = new Regex("[ ]{1,}", RegexOptions.None).Replace(source, "_");
            return new Regex("([^^])([A-Z])", RegexOptions.CultureInvariant).Replace(source, (Match m) => $"{m.Groups[1]}_{m.Groups[2]}").ToLowerInvariant();
        }

        public static string ToKebabCasing(this string source)
        {
            source = new Regex("[ ]{1,}", RegexOptions.None).Replace(source, "-");
            return new Regex("([^^])([A-Z])", RegexOptions.CultureInvariant).Replace(source, (Match m) => $"{m.Groups[1]}-{m.Groups[2]}").ToLowerInvariant();
        }

        public static string CamelToTitleCasing(this string source)
        {
            string text = Regex.Replace(source, "\\p{Lu}", (Match m) => " " + m.Value.ToLowerInvariant());
            return char.ToUpperInvariant(text[0]) + text.Substring(1);
        }

        private static string GenerateSlug(string value, int? maxLength = null)
        {
            string input = value.RemoveDiacritics().Replace("-", " ").ToLowerInvariant();
            input = Regex.Replace(input, "[^a-z0-9\\s-]", string.Empty);
            input = Regex.Replace(input, "\\s+", " ").Trim();
            if (maxLength.HasValue)
            {
                input = input.Substring(0, (input.Length <= maxLength) ? input.Length : maxLength.Value).Trim();
            }

            return Regex.Replace(input, "\\s", "-");
        }

        public static IEnumerable<string> SplitAndTrim(this string value, params char[] separators)
        {
            Ensure.Argument.NotNull(value, "source");
            return from s in value.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries)
                   select s.Trim();
        }

        public static bool Contains(this string source, string input, StringComparison comparison)
        {
            return source.IndexOf(input, comparison) >= 0;
        }

        public static string NormalizeForSearch(this string source)
        {
            return source.RemoveDiacritics().ToUpper();
        }

        public static string RemoveDiacritics(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            try
            {
                str = str.ToLower().Trim();
                str = Regex.Replace(str, "[\\r|\\n]", " ");
                str = Regex.Replace(str, "\\s+", " ");
                str = Regex.Replace(str, "[áàảãạâấầẩẫậăắằẳẵặ]", "a");
                str = Regex.Replace(str, "[éèẻẽẹêếềểễệ]", "e");
                str = Regex.Replace(str, "[iíìỉĩị]", "i");
                str = Regex.Replace(str, "[óòỏõọơớờởỡợôốồổỗộ]", "o");
                str = Regex.Replace(str, "[úùủũụưứừửữự]", "u");
                str = Regex.Replace(str, "[yýỳỷỹỵ]", "y");
                str = Regex.Replace(str, "[đ]", "d");
                str = Regex.Replace(str, "[\"`~!@#$%^&*()-+=?/>.<,{}[]|]\\]", "");
                str = str.Replace("\u0300", "").Replace("\u0323", "").Replace("\u0309", "")
                    .Replace("\u0303", "")
                    .Replace("\u0301", "");
                return str;
            }
            catch (Exception)
            {
                return str;
            }
        }

        public static string Limit(this string source, int maxLength, string suffix = null)
        {
            if (suffix.IsNotNullOrEmpty() && suffix != null)
            {
                maxLength -= suffix.Length;
            }

            if (source.Length <= maxLength)
            {
                return source;
            }

            return source.Substring(0, maxLength).Trim() + (suffix ?? string.Empty);
        }

        public static T ParseEnum<T>(this string value, T defaultValue = default(T)) where T : struct, IConvertible
        {
            if (!System.Enum.TryParse<T>(value, ignoreCase: true, out var result))
            {
                return defaultValue;
            }

            return result;
        }

        public static string StripHtml(this string source)
        {
            return TagsExpression.Replace(source, string.Empty);
        }

        public static Guid? ToGuid(this string str)
        {
            if (Guid.TryParse(str, out var result))
            {
                return result;
            }

            return null;
        }

        public static (string, string) GuessS3ObjectInfo(this string url)
        {
            Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);
            string empty = string.Empty;
            empty = ((!uri.IsAbsoluteUri) ? url : uri.AbsolutePath.TrimStart('/'));
            int num = empty.IndexOf("/", StringComparison.CurrentCultureIgnoreCase);
            return (empty.Substring(0, num), empty.Substring(num + 1));
        }

        public static string HtmlDeepDecode(this string source, int maxLevel = 3)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }

            int i = 1;
            string text = string.Empty;
            for (; i <= maxLevel; i++)
            {
                text = HttpUtility.HtmlDecode(source);
                if (text == source)
                {
                    break;
                }

                source = text;
            }

            return text;
        }
    }
    public static class Ensure
    {
        public static class Argument
        {
            public static void Is(bool condition, string message = "")
            {
                That<ArgumentException>(condition, message);
            }

            public static void IsNot(bool condition, string message = "")
            {
                Is(!condition, message);
            }

            public static void NotNull(object value, string paramName = "")
            {
                That<ArgumentNullException>(value != null, paramName);
            }

            public static void NotNullOrEmpty(string value, string paramName = "")
            {
                if (value.IsNullOrEmpty())
                {
                    if (paramName.IsNullOrEmpty())
                    {
                        throw new ArgumentException("String value cannot be empty");
                    }

                    throw new ArgumentException("String parameter " + paramName + " cannot be null or empty", paramName);
                }
            }
        }

        public static void That(bool condition, string message = "")
        {
            That<Exception>(condition, message);
        }

        public static void That<TException>(bool condition, string message = "") where TException : Exception
        {
            if (!condition)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        public static void Not<TException>(bool condition, string message = "") where TException : Exception
        {
            That<TException>(!condition, message);
        }

        public static void Not(bool condition, string message = "")
        {
            Not<Exception>(condition, message);
        }

        public static void NotNull(object value, string message = "")
        {
            That<NullReferenceException>(value != null, message);
        }

        public static void Equal<T>(T left, T right, string message = "Values must be equal")
        {
            That(left != null && right != null && left.Equals(right), message);
        }

        public static void NotEqual<T>(T left, T right, string message = "Values must not be equal")
        {
            That(left != null && right != null && !left.Equals(right), message);
        }

        public static void Contains<T>(IEnumerable<T> collection, Func<T, bool> predicate, string message = "")
        {
            That(collection?.Any(predicate) ?? false, message);
        }

        public static void Items<T>(IEnumerable<T> collection, Func<T, bool> predicate, string message = "")
        {
            That(collection?.All(predicate) ?? false);
        }

        public static void NotNullOrEmpty(string value, string message = "String cannot be null or empty")
        {
            That(value.IsNotNullOrEmpty(), message);
        }
    }

}
