using LenSys.Models.BusniessDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessDetailsController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("BusniessDetails");
        }
        [HttpGet]
        public ViewResult BusniessDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BusniessDetails(BusniessDetails individual)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("BusniessDetails");
            }

            return View();
        }

    }
}
