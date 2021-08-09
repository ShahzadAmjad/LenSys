using LenSys.Models.BusniessLiabilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessLiabilitiesController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("BusniessLiabilities");
        }
        [HttpGet]
        public ViewResult BusniessLiabilities()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BusniessLiabilities(BusniessLiabilities busniessLiabilities)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("BusniessLiabilities");
            }

            return View();
        }
    }
}
