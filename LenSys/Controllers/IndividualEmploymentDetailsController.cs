using LenSys.Models.IndividualEmploymentDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualEmploymentDetailsController: Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("EmploymentDetails");
        }
        [HttpGet]
        public ViewResult EmploymentDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmploymentDetails(EmploymentDetails employmentDetails)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("EmploymentDetails");
            }

            return View();
        }
    }
}
