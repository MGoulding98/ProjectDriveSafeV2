using ProjectDriveSafeV2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDriveSafeV2.Components
{
    public class CountiesViewComponent : ViewComponent
    {
        // The purpose of this component is to allow us to filter by different counties on our summary page
        private ICollisionRepository repo { get; set; }

        public CountiesViewComponent(ICollisionRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCounty = RouteData?.Values["county"];

            var counties = repo.Crashes
                .Select(x => x.COUNTY_NAME)
                .Distinct()
                .OrderBy(x => x);

            return View(counties);
        }
    }
}

