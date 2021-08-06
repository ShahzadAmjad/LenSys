using LenSys.Models.IndividualAddressDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualAddressDetailsController: Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AddressDetails");
        }
        [HttpGet]
        public ViewResult AddressDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddressDetails(AddressDetails addressDetails)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("AddressDetails");
            }

            return View();
        }

    }
}
