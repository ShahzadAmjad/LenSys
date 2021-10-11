using LenSys.Models.AppPropertyFinance;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
using LenSys.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class AppPropertyFinanceController : Controller
    {
        private IAppPropertyFinanceSecurityDetailsRepository _appPropertyFinanceSecurityDetails;
        private IAppPropertyFinanceRepository _appPropertyFinanceRepository;
        private IAppPropertyFinanceBusniessRepository _appPropertyFinanceBusniessRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;
        //Shared Variables
        public static int appID;
        public static int IndividualID;
        public static int BusniessID;
        public static Lead lead;
        public AppPropertyFinanceController(IAppPropertyFinanceSecurityDetailsRepository appPropertyFinanceSecurityDetailsRepository,
            IAppPropertyFinanceRepository appPropertyFinanceRepository,
            IAppPropertyFinanceBusniessRepository appPropertyFinanceBusniessRepository,
            IAppPropertyFinanceIndividualRepository appPropertyFinanceIndividualRepository)
        {
            _appPropertyFinanceSecurityDetails = appPropertyFinanceSecurityDetailsRepository;
            _appPropertyFinanceRepository = appPropertyFinanceRepository;
            _appPropertyFinanceBusniessRepository = appPropertyFinanceBusniessRepository;
            _appPropertyFinanceIndividualRepository = appPropertyFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            AppPropertyFinance AppPropertyFinanceApplication;
            //Saving to global variables
            appID = HomeController.EditBusinessFinanceAppID;

            if (appID == 0)
            {
                AppPropertyFinanceApplication = new AppPropertyFinance();
            }
            else
            {
                AppPropertyFinanceApplication = _appPropertyFinanceRepository.GetAppPropertyFinance_appPropertyFinance(appID);
                AppPropertyFinanceApplication.busniesses = (List<AppPropertyFinanceBusniess>)_appPropertyFinanceBusniessRepository.GetAllBusniess();
                AppPropertyFinanceApplication.individuals = (List<AppPropertyFinanceIndividual>)_appPropertyFinanceIndividualRepository.GetAllIndividual();
                AppPropertyFinanceApplication.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
                //Saving to global variables
                lead = AppPropertyFinanceApplication.Lead;
            }
            return View("AppPropertyFinance", AppPropertyFinanceApplication);

            //return View("AppPropertyFinance");
        }

        [HttpGet]
        public IActionResult AddSecurityDetail()
        {

            AppPropertyFinanceSecurityDetails securityDetails = new AppPropertyFinanceSecurityDetails();
            return PartialView("_AddSecutityDetailPropertyPartialView", securityDetails);

            //return View("EditSecurityDetail", model);
        }
        [HttpPost]
        public IActionResult AddSecurityDetail(AppPropertyFinanceSecurityDetails securityDetails)
        {
            _appPropertyFinanceSecurityDetails.Add(securityDetails);
            //AppBusniessFinanceSecurityDetails securityDetails = new AppBusniessFinanceSecurityDetails();
            //return PartialView("_AddSecutityDetailBusniessPartialView", securityDetails);

            //ViewData["SecurityDetailsList"] = _appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            AppPropertyFinance appPropertyFinance = new AppPropertyFinance();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();

            return View("AppPropertyFinance", appPropertyFinance);
        }


        [HttpGet]
        public IActionResult EditSecurityDetail(int id)
        {


            AppPropertyFinanceSecurityDetails securityDetails = _appPropertyFinanceSecurityDetails.GetAppPropertysFinanceSecurityDetails(id);
            //return View("EditSecurityDetail",model);

            return PartialView("_EditSecurityDetailPropertyPartialView", securityDetails);

        }
        public ViewResult DeleteSecurityDetail(int id)
        {
            _appPropertyFinanceSecurityDetails.Delete(id);
            AppPropertyFinance appPropertyFinance = new AppPropertyFinance();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            return View("AppPropertyFinance", appPropertyFinance);
        }
        [HttpGet]
        public ViewResult AppPropertyFinance()
        {

            //ViewData["SecurityDetailsList"] = _appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            AppPropertyFinance appPropertyFinance = new AppPropertyFinance();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();

            return View("AppPropertyFinance", appPropertyFinance);

            //return View();
        }
        [HttpPost]
        public IActionResult AppPropertyFinance(AppPropertyFinance appPropertyFinance)
        {
            var securitydetailList = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            
            //Primary key cannot be given so making it zeo for all
            foreach(var securitydetail in securitydetailList)
            {
                securitydetail.SecurityDetailsId = 0;
            }


            appPropertyFinance.securityDetails = securitydetailList;

            //if (ModelState.IsValid)
            {
                AppPropertyFinance appPropertyFinance1 = _appPropertyFinanceRepository.Add(appPropertyFinance);

            }
            
            appPropertyFinance = new AppPropertyFinance();
            securitydetailList.Clear();
            appPropertyFinance.securityDetails = securitydetailList;
            return View("AppPropertyFinance", appPropertyFinance);
            
        }
    }
}
