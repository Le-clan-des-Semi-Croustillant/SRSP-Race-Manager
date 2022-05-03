using System.Globalization;
namespace RaceManager.Language
{
    public class LocaleManager
    {
        private static RMLogger _logger = new ("LocaleManager");
        public static string CurrentCulture { get; set; } = "en-US";

        /// <summary>
        /// Update the current culture with the given culture
        /// </summary>
        /// <param name="culture">Selected culture</param>
        public static void UpdateCulture(string culture)
        {
            _logger.log(LoggingLevel.INFO, "UpdateCulture()", "Updating culture to " + culture);
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo(culture);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
        }

        /// <summary>
        /// Update the culture with current culture
        /// </summary>
        public static void UpdateCulture()
        {
            UpdateCulture(CurrentCulture);
        }

    }
}
