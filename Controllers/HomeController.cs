using ProjectDriveSafeV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProjectDriveSafeV2.Models.ViewModels;

namespace ProjectDriveSafeV2.Controllers
{
    public class HomeController : Controller
    {
        private ICollisionRepository repo { get; set; }

        public HomeController(ICollisionRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewCrashes(string county, int pageNum = 1)
        {
            int pageSize = 50;

            var x = new CrashesViewModel
            {
                Crashes = repo.Crashes
                .Where(c => c.COUNTY_NAME == county || county == null)
                .OrderBy(c => c.CRASH_ID)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumCrashes = (county == null
                        ? repo.Crashes.Count()
                        : repo.Crashes.Where(x => x.COUNTY_NAME == county).Count()),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        //Get Crash Details
        public IActionResult CrashDetails(int crashid)
        {
            Crash c = repo.GetCrash(crashid);
            return View(c);
        }


        public IActionResult DataViz()
        {
            return View();
        }
    }
}
