using LenSys.Models.BusniessKeyPrincipals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessKeyPrincipalsController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("KeyPrincipals");
        }
        [HttpGet]
        public ViewResult KeyPrincipals()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KeyPrincipals(KeyPrincipals keyPrincipals)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("KeyPrincipals");
            }

            return View();
        }

    }
}
