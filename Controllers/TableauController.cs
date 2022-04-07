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
    }
}
