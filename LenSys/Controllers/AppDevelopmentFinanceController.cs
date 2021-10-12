using LenSys.Models.AppDevelopmentFinance;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.Home;
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
        private IAppDevelopmentFinanceBusniessRepository _appDevelopmentFinanceBusniessRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        //Shared Variables
        public static int appID;
        public static int IndividualID;
        public static int BusniessID;
        public static Lead lead;
        public AppDevelopmentFinanceController(IAppDevelopmentFinanceSecurityDetailsRepository appDevelopmentFinanceSecurityDetailsRepository,
            IAppDevelopmentFinanceRepository appDevelopmentFinanceRepository,
            IAppDevelopmentFinanceBusniessRepository appDevelopmentFinanceBusniessRepository,
            IAppDevelopmentFinanceIndividualRepository appDevelopmentFinanceIndividualRepository)
        {
            _appDevelopmentFinanceSecurityDetails = appDevelopmentFinanceSecurityDetailsRepository;
            _appDevelopmentFinanceRepository = appDevelopmentFinanceRepository;
            _appDevelopmentFinanceBusniessRepository = appDevelopmentFinanceBusniessRepository;
            _appDevelopmentFinanceIndividualRepository = appDevelopmentFinanceIndividualRepository;
        }


        public ViewResult Index()
        {
            AppDevelopmentFinance AppDevelopmentFinanceApplication;
            //Saving to global variables
            appID = HomeController.EditBusinessFinanceAppID;

            if (appID == 0)
            {
                AppDevelopmentFinanceApplication = new AppDevelopmentFinance();
            }
            else
            {
                AppDevelopmentFinanceApplication = _appDevelopmentFinanceRepository.GetAppDevelopmentFinance_appDevelopmentFinance(appID);
                AppDevelopmentFinanceApplication.busniesses = (List<AppDevelopmentFinanceBusniess>)_appDevelopmentFinanceBusniessRepository.GetAllBusniess();
                AppDevelopmentFinanceApplication.individuals = (List<AppDevelopmentFinanceIndividual>)_appDevelopmentFinanceIndividualRepository.GetAllIndividual();
                AppDevelopmentFinanceApplication.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
                //Saving to global variables
                lead = AppDevelopmentFinanceApplication.Lead;
            }
            return View("AppDevelopmentFinance", AppDevelopmentFinanceApplication);
            //return View("AppDevelopmentFinance");
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
            return PartialView("_EditSecurityDetailDevelopmentPartialView", securityDetails);
        }

        public ViewResult DeleteSecurityDetail(int id)
        {
            _appDevelopmentFinanceSecurityDetails.Delete(id);
            AppDevelopmentFinance appDevelopmentFinance = new AppDevelopmentFinance();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance", appDevelopmentFinance);
        }
        [HttpGet]
        public ViewResult AppDevelopmentFinance()
        {
            AppDevelopmentFinance AppDevelopmentFinanceApplication;
            //Saving to global variables
            appID = HomeController.EditDevelopmentFinanceAppID;

            if (appID == 0)
            {
                AppDevelopmentFinanceApplication = new AppDevelopmentFinance();
            }
            else
            {

                AppDevelopmentFinanceApplication = _appDevelopmentFinanceRepository.GetAppDevelopmentFinance_appDevelopmentFinance(appID);
                AppDevelopmentFinanceApplication.busniesses = (List<AppDevelopmentFinanceBusniess>)_appDevelopmentFinanceBusniessRepository.GetAllBusniess();
                AppDevelopmentFinanceApplication.individuals = (List<AppDevelopmentFinanceIndividual>)_appDevelopmentFinanceIndividualRepository.GetAllIndividual();
                AppDevelopmentFinanceApplication.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
                
                //Saving to global variables
                lead = AppDevelopmentFinanceApplication.Lead;
            }
            return View("AppDevelopmentFinance", AppDevelopmentFinanceApplication);
            //AppDevelopmentFinance appDevelopmentFinance = new AppDevelopmentFinance();
            //appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            //return View("AppDevelopmentFinance", appDevelopmentFinance);
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
