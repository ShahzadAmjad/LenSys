using LenSys.Models.IndividualLiabilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualLiabilitiesController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("Liabilities");
        }
        [HttpGet]
        public ViewResult Liabilities()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Liabilities(Liabilities monthlyExpenditure)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("Liabilities");
            }

            return View();
        }
    }
}
