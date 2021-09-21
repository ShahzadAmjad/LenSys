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
        private IAppBusniessFinanceRepository _appBusniessFinanceRepository;
        //public List<AppBusniessFinanceSecurityDetails> _SecurityDetails;
        //AppBusniessFinance GappBusniessFinance = new AppBusniessFinance();
        public AppBusniessFinanceController(IAppBusniessFinanceSecurityDetailsRepository appBusniessFinanceSecurityDetailsRepository, IAppBusniessFinanceRepository appBusniessFinanceRepository)
        {
            _appBusniessFinanceSecurityDetails = appBusniessFinanceSecurityDetailsRepository;
            _appBusniessFinanceRepository = appBusniessFinanceRepository;
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
        }
        [HttpPost]
        public IActionResult AddSecurityDetail(AppBusniessFinanceSecurityDetails securityDetails)
        {
            _appBusniessFinanceSecurityDetails.Add(securityDetails);
            //AppBusniessFinanceSecurityDetails securityDetails = new AppBusniessFinanceSecurityDetails();
            //return PartialView("_AddSecutityDetailBusniessPartialView", securityDetails);

            //ViewData["SecurityDetailsList"] = _appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            AppBusniessFinance appBusniessFinance = new AppBusniessFinance();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);
        }
        [HttpGet]
        public IActionResult EditSecurityDetail(int id)
        {
            AppBusniessFinanceSecurityDetails securityDetails = _appBusniessFinanceSecurityDetails.GetAppBusniessFinanceSecurityDetails(id);
            //return View("EditSecurityDetail",model);
            return PartialView("_EditSecurityDetailBusniessPartialView", securityDetails);
        }
        [HttpPost]
        public IActionResult EditSecurityDetail(AppBusniessFinanceSecurityDetails appBusniessFinanceSecurityDetailsChanges)
        {
            //if (ModelState.IsValid)
            {
                _appBusniessFinanceSecurityDetails.Update(appBusniessFinanceSecurityDetailsChanges);
            }
            AppBusniessFinance appBusniessFinance = new AppBusniessFinance();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);
            //return View();
        }
        public ViewResult DeleteSecurityDetail(int id)
        {
            _appBusniessFinanceSecurityDetails.Delete(id);
            AppBusniessFinance appBusniessFinance = new AppBusniessFinance();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);
        }
        [HttpGet]
        public ViewResult AppBusniessFinance()
        {
            AppBusniessFinance appBusniessFinance = new AppBusniessFinance();

            appBusniessFinance.securityDetails= (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            //ViewData["SecurityDetailsList"] = _appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);
        }
        [HttpPost]
        public IActionResult AppBusniessFinance(AppBusniessFinance appBusniessFinance)
        {
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();

            //if (ModelState.IsValid)
            //{

                AppBusniessFinance appBusniessFinance1 = _appBusniessFinanceRepository.Add(appBusniessFinance);
           // }

            
            
            AppBusniessFinance appBusniessFinance2 = new AppBusniessFinance();
            var List= (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            List.Clear();
            appBusniessFinance2.securityDetails = List;
            return View("AppBusniessFinance", appBusniessFinance2);
        }
    }
}
