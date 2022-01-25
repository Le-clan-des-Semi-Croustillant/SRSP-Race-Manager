using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RaceManager.Models;

namespace RaceManager.Controllers
{
    public class ConfigController : Controller
    {
        private readonly ILogger<ConfigController> _logger;

        //public ConfigController(ILogger<RaceManagerController> logger)
        //{
        //    _logger = logger;
        //}

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
