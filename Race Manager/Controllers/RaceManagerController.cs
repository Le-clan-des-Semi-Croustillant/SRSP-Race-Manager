using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using RaceManager.locales;
using RaceManager.Models;

namespace RaceManager.Controllers
{
    public class RaceManagerController : CulturedController
    {
        private readonly ILogger<RaceManagerController> _logger;

        public RaceManagerController(ILogger<RaceManagerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Console.WriteLine(locale.GridDesc);

            return View();
        }

        public IActionResult Gpx()
        {
            return View();
        }

        public IActionResult Grid()
        {
            return View();
        }

        public IActionResult Config()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult SettingsUpdated(Models.SettingsModel sm)
        {
            //ViewBag.Language = sm.Language;
            ViewBag.Port = sm.Port;

            if (sm.Language != null && !sm.Language.Equals(""))
            {
                Console.WriteLine("new language = " + sm.Language + "\n");
                CurrentCulture = sm.Language;
            }

            if (sm.Port != null && sm.Port >1000 && sm.Port < 5000)
            {
                Console.WriteLine("new port = " + sm.Port);
                //Communication.AsyncServer.Port = sm.Port;
                //Communication.AsyncServer.Stop();
                //Communication.AsyncServer.Run();
            }

            ViewBag.Language = sm.Language;
            ViewBag.Port = sm.Port;

            
            return View("Config");
            //return this.Config();
        }
    }
}