using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDriveSafeV2.Controllers
{
    public class TableauController : Controller
    {
        public IActionResult DataViz()
        {
            return View();
        }
        public IActionResult CountySeverity()
        {
            return View();
        }

        public IActionResult CrashSeverity()
        {
            return View();
        }
        public IActionResult Map()
        {
            return View();
        }

        public IActionResult Bubble()
        {
            return View();
        }

    }
}
