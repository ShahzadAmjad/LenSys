using LenSys.Models.IndividualPersonalDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualPersonalDetailsController: Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("PersonalDetails");
        }
        [HttpGet]
        public ViewResult PersonalDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PersonalDetails(PersonalDetails individual)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("PersonalDetails");
            }

            return View();
        }


    }
}
