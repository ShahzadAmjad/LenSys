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
        private IAppBusniessFinanceSecurityDetailsRepository _appBusniessFinanceSecurityDetails;
        //public List<AppBusniessFinanceSecurityDetails> _SecurityDetails;

        public AppBusniessFinanceController(IAppBusniessFinanceSecurityDetailsRepository appBusniessFinanceSecurityDetailsRepository)
        {
            _appBusniessFinanceSecurityDetails = appBusniessFinanceSecurityDetailsRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AppBusniessFinance");
        }

        [HttpGet]
        public ViewResult EditSecurityDetail(int id)
        {
            

            AppBusniessFinanceSecurityDetails model = _appBusniessFinanceSecurityDetails.GetAppBusniessFinanceSecurityDetails(id);
            //ViewBag.PageTitle = "Edit Security details";

            return View("EditSecurityDetail",model);
        }

        [HttpGet]
        public ViewResult AppBusniessFinance()
        {
            //_SecurityDetails = new List<AppBusniessFinanceSecurityDetails>() 
            //{
            //    new AppBusniessFinanceSecurityDetails
            //    {
            //            SecurityDetailsId=1,
            //            Notes="Security Property",
            //            LegalChargeOverProperty="YES",
            //            SecurityType= "Residential ",
            //            PropertyType="1 Bed Appartment",
            //            NameOfPropertyOwner = "John",
            //            Tenure= 2,
            //            YearsRemainingOnLeaseIfLeaseHold= 1,
            //            PropertyValue= 5454,
            //            OriginalPurchasePrice= 6000,
            //            AddressForPropertyOfSecurity="Russia",
            //            SecondLineAddress= "Cremlin",
            //            City= "Moscow",
            //            PostCode= 85000
                       
            //    }
            //};


           
            ViewData["SecurityDetailsList"] = _appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();



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
