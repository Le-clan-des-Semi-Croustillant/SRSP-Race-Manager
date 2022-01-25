using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RaceManager.Models;

namespace RaceManager.Controllers
{
    public class RaceManagerController : Controller
    {
        private readonly ILogger<RaceManagerController> _logger;

        public RaceManagerController(ILogger<RaceManagerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
    }
}