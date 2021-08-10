using LenSys.Models;
using LenSys.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class HomeController: Controller
    {

        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("Lead");
        }
        [HttpGet]
        public ViewResult Lead()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Lead(Lead lead)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("Lead");
            }

            return View();
        }

    }
}
