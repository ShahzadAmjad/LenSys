using LenSys.Models.BusniessServiceability;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessServiceabilityController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("Serviceability");
        }
        [HttpGet]
        public ViewResult Serviceability()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KeyPrincipals(Serviceability serviceability)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("Serviceability");
            }

            return View();
        }
    }
}
