using System.Globalization;

namespace RaceManager.Language
{
    public class LocaleManager
    {
        public static string CurrentCulture { get; set; } = "en-US";

        public static void UpdateCulture(string culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo(culture);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
        }

        public static void UpdateCulture()
        {
            UpdateCulture(CurrentCulture);
        }

    }
}
