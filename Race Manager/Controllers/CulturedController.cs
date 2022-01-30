using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace RaceManager.Controllers
{
    public class CulturedController : Controller
    {
        static public string CurrentCulture { get; set; } = "en-US";

        public static void UpdateCulture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(CurrentCulture); 
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(CurrentCulture);
        }

        public override void OnActionExecuting(
         ActionExecutingContext filterContext)
        {
            UpdateCulture();
            base.OnActionExecuting(filterContext);
        }
    }
}
