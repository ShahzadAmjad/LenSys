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
        public IActionResult AddSecurityDetail()
        {

            AppBusniessFinanceSecurityDetails securityDetails = new AppBusniessFinanceSecurityDetails();
            return PartialView("_AddSecutityDetailBusniessPartialView", securityDetails);

            //return View("EditSecurityDetail", model);
        }
        [HttpPost]
        public IActionResult AddSecurityDetail(AppBusniessFinanceSecurityDetails securityDetails)
        {
            _appBusniessFinanceSecurityDetails.Add(securityDetails);
            //AppBusniessFinanceSecurityDetails securityDetails = new AppBusniessFinanceSecurityDetails();
            //return PartialView("_AddSecutityDetailBusniessPartialView", securityDetails);

            ViewData["SecurityDetailsList"] = _appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance");
        }


        [HttpGet]
        public IActionResult EditSecurityDetail(int id)
        {
            

            AppBusniessFinanceSecurityDetails securityDetails = _appBusniessFinanceSecurityDetails.GetAppBusniessFinanceSecurityDetails(id);
            //return View("EditSecurityDetail",model);

            return PartialView("_EditSecurityDetailBusniessPartialView", securityDetails);

        }

        [HttpGet]
        public ViewResult AppBusniessFinance()
        {
          
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
