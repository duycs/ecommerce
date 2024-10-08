namespace ECommerce.Shared.Dotnet
{
    public static class CultureName
    {
        public const string Vietnamese = "vi-VN";

        public const string English = "en-US";

        public static string Default = "vi-VN";

        public static string FromLocale(Locale locale)
        {
            if (locale == Locale.English)
            {
                return "en-US";
            }

            return "vi-VN";
        }
    }
    public enum Locale
    {
        English = 1,
        Vietnamese
    }
}
