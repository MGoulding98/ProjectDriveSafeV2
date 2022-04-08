using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectDriveSafeV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ProjectDriveSafeV2.Models.ViewModels;

namespace ProjectDriveSafeV2.Controllers
{
    public class AdminController : Controller
    {
        private ICollisionRepository _repo { get; set; }

        // constructor
        public AdminController(ICollisionRepository temp)
        {
            _repo = temp;
        }

        [Authorize]
        public IActionResult AdminView(string county, int pageNum = 1)
        {
            int pageSize = 50;

            var x = new CrashesViewModel
            {
                Crashes = _repo.Crashes
                .Where(x => x.COUNTY_NAME == county || county == null)
                .OrderBy(c => c.CRASH_ID)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumCrashes = _repo.Crashes.Count(),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            //IQueryable<Crash> blah = _repo.Crashes.Where(x => x.COUNTY_NAME == county || county == null);

            return View(x);
        }

        [HttpGet]
        public IActionResult CrashForm()
        {
            ViewBag.Crashes = _repo.Crashes.ToList();

            return View(new Crash());
        }

        [HttpPost]
        public IActionResult CrashForm(Crash c)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateCollision(c);

                return RedirectToAction("AdminView");
            }
            else
            {
                ViewBag.Crashes = _repo.Crashes.ToList();
                return View(c);
            }
        }

        // Edit Crash

        [HttpGet]
        public IActionResult EditCrash(int crashid)
        {
            ViewBag.Crashes = _repo.Crashes.ToList();

            Crash c = _repo.GetCrash(crashid);
            return View("CrashFormEdit", c);
        }

        [HttpPost]
        public IActionResult EditCrash(Crash c)
        {
            _repo.EditCollision(c);

            return RedirectToAction("AdminView");
        }


        // Delete Crash
        [HttpGet]
        public IActionResult DeleteCrash(int crashid)
        {
            Crash c = _repo.GetCrash(crashid);
            return View(c);
        }

        [HttpPost]
        public IActionResult DeleteCrash (Crash c)
        {
            _repo.DeleteCollision(c);

            return RedirectToAction("AdminView");
        }
        //Get Crash Details
        public IActionResult CrashDetailsAdmin(int crashid)
        {
            Crash c = _repo.GetCrash(crashid);
            return View(c);
        }
    }
}

