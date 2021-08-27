using LenSys.Models.AppDevelopmentFinance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class AppDevelopmentFinanceController: Controller
    {
        private IAppDevelopmentFinanceSecurityDetailsRepository _appDevelopmentFinanceSecurityDetails;
        //public List<AppDevelopmentFinanceSecurityDetails> _SecurityDetails;
        public AppDevelopmentFinanceController(IAppDevelopmentFinanceSecurityDetailsRepository appDevelopmentFinanceSecurityDetailsRepository)
        {
            _appDevelopmentFinanceSecurityDetails = appDevelopmentFinanceSecurityDetailsRepository;
        }
        

        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AppDevelopmentFinance");
        }

        [HttpGet]
        public IActionResult AddSecurityDetail()
        {

            AppDevelopmentFinanceSecurityDetails securityDetails = new AppDevelopmentFinanceSecurityDetails();
            return PartialView("_AddSecutityDetailBusniessPartialView", securityDetails);

            //return View("EditSecurityDetail", model);
        }
        [HttpPost]
        public IActionResult AddSecurityDetail(AppDevelopmentFinanceSecurityDetails securityDetails)
        {
            _appDevelopmentFinanceSecurityDetails.Add(securityDetails);
            //AppBusniessFinanceSecurityDetails securityDetails = new AppBusniessFinanceSecurityDetails();
            //return PartialView("_AddSecutityDetailBusniessPartialView", securityDetails);

            ViewData["SecurityDetailsList"] = _appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance");
        }

        [HttpGet]
        public ViewResult EditSecurityDetail(int id)
        {


            AppDevelopmentFinanceSecurityDetails model = _appDevelopmentFinanceSecurityDetails.GetAppDevelopmentFinanceSecurityDetails(id);
            //ViewBag.PageTitle = "Edit Key Principal";

            return View("EditSecurityDetail",model);
        }
        [HttpGet]
        public ViewResult AppDevelopmentFinance()
        {
            //_SecurityDetails = new List<AppDevelopmentFinanceSecurityDetails>()
            //{
            //    new AppDevelopmentFinanceSecurityDetails
            //    {
            //            SecurityDetailsId=1,
                        
                        
            //            SecurityType= "Residential ",
            //            DescriptionOfProperty= "Residential Plot",
            //            PropertyCurrentUse="Abondon",                        
            //            NameOfPropertyOwner = "John",
            //            Tenure= 2,
            //            YearsRemainingOnLeaseIfLeaseHold= 1,
            //            AddressForPropertyOfSecurity="Russia",
            //            SecondLineAddress= "Cremlin",
            //            City= "Moscow",
            //            PostCode= 85000

            //    }
            //};

            ViewData["SecurityDetailsList"] = _appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();

            return View("AppDevelopmentFinance");

            //return View();
        }
        [HttpPost]
        public IActionResult AppDevelopmentFinance(AppDevelopmentFinance appBusniessFinance)
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
