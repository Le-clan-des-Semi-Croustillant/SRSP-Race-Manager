﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RaceManager.Models;

namespace RaceManager.Controllers
{
    public class ConfigController : CulturedController
    {
        private readonly ILogger<ConfigController> _logger;

        public ConfigController(ILogger<ConfigController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult form1(int txtId, string txtName, string chkAddon)
        {
            ViewBag.Id = txtId;
            ViewBag.Name = txtName;
            if (chkAddon != null)
                ViewBag.Addon = "Selected";
            else
                ViewBag.Addon = "Not Selected";

            return View("Config");

        }

        [HttpPost]
        public ActionResult Form2(Models.StudentModel sm)
        {
            ViewBag.Id = sm.Id;
            ViewBag.Name = sm.Name;
            if (sm.Addon == true)
                ViewBag.Addon = "Selected";
            else
                ViewBag.Addon = "Not Selected";

            return View("Config");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
