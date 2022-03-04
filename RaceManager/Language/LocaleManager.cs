using System.Globalization;

namespace RaceManager.Language
{
    public class LocaleManager
    {
        static public string CurrentCulture { get; set; } = "en-US";

        public static void UpdateCulture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(CurrentCulture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(CurrentCulture);
        }

    }
}
