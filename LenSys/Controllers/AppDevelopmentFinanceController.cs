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
        private IAppDevelopmentFinanceRepository _appDevelopmentFinanceRepository;
        public AppDevelopmentFinanceController(IAppDevelopmentFinanceSecurityDetailsRepository appDevelopmentFinanceSecurityDetailsRepository, IAppDevelopmentFinanceRepository appDevelopmentFinanceRepository)
        {
            _appDevelopmentFinanceSecurityDetails = appDevelopmentFinanceSecurityDetailsRepository;
            _appDevelopmentFinanceRepository = appDevelopmentFinanceRepository;
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

            //ViewData["SecurityDetailsList"] = _appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            AppDevelopmentFinance appDevelopmentFinance = new AppDevelopmentFinance();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();

            return View("AppDevelopmentFinance", appDevelopmentFinance);
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

            //ViewData["SecurityDetailsList"] = _appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            AppDevelopmentFinance appDevelopmentFinance = new AppDevelopmentFinance();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance", appDevelopmentFinance);
        }
        [HttpPost]
        public IActionResult AppDevelopmentFinance(AppDevelopmentFinance appDevelopmentFinance)
        {
            var securitydetailList = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();

            //Primary key cannot be given so making it zeo for all
            foreach (var securitydetail in securitydetailList)
            {
                securitydetail.SecurityDetailsId = 0;
            }

            appDevelopmentFinance.securityDetails = securitydetailList;

            if (ModelState.IsValid)
            {
                AppDevelopmentFinance appDevelopmentFinance1 = _appDevelopmentFinanceRepository.Add(appDevelopmentFinance);

            }
            
            appDevelopmentFinance = new AppDevelopmentFinance();          
            securitydetailList.Clear();
            appDevelopmentFinance.securityDetails = securitydetailList;
            return View("AppDevelopmentFinance", appDevelopmentFinance);
            //return View("AllApplications", "Home");
        }
    }
}
