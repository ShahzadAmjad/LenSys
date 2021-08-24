using LenSys.Models.AppBusniessFinance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class AppBusniessFinanceController : Controller
    {
        public List<AppBusniessFinanceSecurityDetails> _SecurityDetails;
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AppBusniessFinance");
        }
        [HttpGet]
        public ViewResult AppBusniessFinance()
        {
            //Dummy Data for Security Details
            var securityDetails = new AppBusniessFinanceSecurityDetails
            {
                Notes="Security Property",
                LegalChargeOverProperty="YES",
                SecurityType= "Residential ",
                PropertyType="1 Bed Appartment",
                NameOfPropertyOwner = "John",
                Tenure= 2,
                YearsRemainingOnLeaseIfLeaseHold= 1,
                PropertyValue= 5454,
                OriginalPurchasePrice= 6000,
                AddressForPropertyOfSecurity="Russia",
                SecondLineAddress= "Cremlin",
                City= "Moscow",
                PostCode= 85000
            };

            _SecurityDetails.Add(securityDetails);
            //AppBusniessFinance model = new AppBusniessFinance();
            //model.securityDetails.Add(securityDetails);

            ViewData["SecurityDetailsList"] = _SecurityDetails;

            return View("AppBusniessFinance");
        }
        [HttpPost]
        public IActionResult AppBusniessFinance(AppBusniessFinance appBusniessFinance)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("Index", "Home");
            }

            return View();
        }
    }
}
