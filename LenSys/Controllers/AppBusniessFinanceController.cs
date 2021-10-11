using LenSys.Models.AppBusniessFinance;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class AppBusniessFinanceController : Controller
    {
        private IAppBusniessFinanceRepository _appBusniessFinanceRepository;              
        private IAppBusniessFinanceBusniessRepository _appBusniessFinanceBusniessRepository;
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppBusniessFinanceSecurityDetailsRepository _appBusniessFinanceSecurityDetails;
        //Shared Variables
        public static int appID;
        public static int IndividualID;
        public static int BusniessID;
        public static Lead lead;
        public AppBusniessFinanceController(IAppBusniessFinanceSecurityDetailsRepository appBusniessFinanceSecurityDetailsRepository,
            IAppBusniessFinanceRepository appBusniessFinanceRepository,
            IAppBusniessFinanceBusniessRepository appBusniessFinanceBusniessRepository,
            IAppBusniessFinanceSecurityDetailsRepository appBusniessFinanceSecurityDetails)
        {
            _appBusniessFinanceSecurityDetails = appBusniessFinanceSecurityDetailsRepository;
            _appBusniessFinanceRepository = appBusniessFinanceRepository;
            _appBusniessFinanceBusniessRepository = appBusniessFinanceBusniessRepository;
            _appBusniessFinanceSecurityDetails = appBusniessFinanceSecurityDetails;
        }
        public ViewResult Index()
        {
            AppBusniessFinance AppBusniessFinanceApplication;
            //Saving to global variables
            appID = HomeController.EditBusinessFinanceAppID;

            if (appID == 0)
            {
                AppBusniessFinanceApplication = new AppBusniessFinance();
            }
            else
            {
                AppBusniessFinanceApplication = _appBusniessFinanceRepository.GetAppBusniessFinance_appBusniessFinance(appID);
                AppBusniessFinanceApplication.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
                AppBusniessFinanceApplication.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
                AppBusniessFinanceApplication.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
                //Saving to global variables
                lead = AppBusniessFinanceApplication.Lead;
            }
            return View("AppBusniessFinance", AppBusniessFinanceApplication);

            //return View("AppBusniessFinance");
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
            AppBusniessFinance AppBusniessFinanceApplication;
            //Saving to global variables
            appID = HomeController.EditBusinessFinanceAppID;

            if (appID == 0)
            {
                AppBusniessFinanceApplication = new AppBusniessFinance();
            }
            else
            {
                AppBusniessFinanceApplication = _appBusniessFinanceRepository.GetAppBusniessFinance_appBusniessFinance(appID);
                AppBusniessFinanceApplication.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
                AppBusniessFinanceApplication.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
                AppBusniessFinanceApplication.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
                //Saving to global variables
                lead = AppBusniessFinanceApplication.Lead;
            }
            return View("AppBusniessFinance", AppBusniessFinanceApplication);
            //AppBusniessFinance appBusniessFinance = new AppBusniessFinance();
            //appBusniessFinance.securityDetails= (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();      
            //return View("AppBusniessFinance", appBusniessFinance);
        }
        [HttpPost]
        public IActionResult AppBusniessFinance(AppBusniessFinance appBusniessFinance)
        {
            foreach(AppBusniessFinanceSecurityDetails SecurityDetails in _appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails())
            {
                SecurityDetails.SecurityDetailsId = 0;
            }

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
