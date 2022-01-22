using Microsoft.AspNetCore.Mvc;
using Race_Manager.Models;
using System.Diagnostics;

namespace Race_Manager.Controllers
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