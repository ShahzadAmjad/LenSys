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
            return PartialView("_AddSecutityDetailDevelopmentPartialView", securityDetails);

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
        public IActionResult EditSecurityDetail(int id)
        {


            AppDevelopmentFinanceSecurityDetails securityDetails = _appDevelopmentFinanceSecurityDetails.GetAppDevelopmentFinanceSecurityDetails(id);
            //ViewBag.PageTitle = "Edit Key Principal";

            //return View("EditSecurityDetail",model);

            return PartialView("_EditSecurityDetailDevelopmentPartialView", securityDetails);
        }
        [HttpGet]
        public ViewResult AppDevelopmentFinance()
        {

            ViewData["SecurityDetailsList"] = _appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();

            return View("AppDevelopmentFinance");
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
