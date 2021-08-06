using LenSys.Models;
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
            return View("IndividualTermLoan");
        }
        [HttpGet]
        public ViewResult IndividualTermLoan()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IndividualTermLoan(Individual individual)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("individualTermLoan");
            }

            return View();
        }

    }
}
