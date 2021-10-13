using LenSys.Models.AppBusniessFinance;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.BusniessDetails;
using LenSys.Models.BusniessKeyPrincipals;
using LenSys.Models.BusniessLiabilities;
using LenSys.Models.BusniessServiceability;
using LenSys.Models.BusniessUploadDocument;
using LenSys.Models.Home;
using LenSys.Models.IndividualAddressDetails;
using LenSys.Models.IndividualAsset;
using LenSys.Models.IndividualCreditHistory;
using LenSys.Models.IndividualEmploymentDetails;
using LenSys.Models.IndividualIncomeExpenditure;
using LenSys.Models.IndividualLiabilities;
using LenSys.Models.IndividualMonthlyExpenditure;
using LenSys.Models.IndividualPersonalDetails;
using LenSys.Models.IndividualPropertySchedule;
using LenSys.Models.IndividualUploadDocuments;
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
            IAppBusniessFinanceSecurityDetailsRepository appBusniessFinanceSecurityDetails,
            IAppBusniessFinanceIndividualRepository appBusniessFinanceIndividualRepository)
        {
            _appBusniessFinanceSecurityDetails = appBusniessFinanceSecurityDetailsRepository;
            _appBusniessFinanceRepository = appBusniessFinanceRepository;
            _appBusniessFinanceBusniessRepository = appBusniessFinanceBusniessRepository;
            _appBusniessFinanceSecurityDetails = appBusniessFinanceSecurityDetails;
            _appBusniessFinanceIndividualRepository = appBusniessFinanceIndividualRepository;
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
        public IActionResult AddBusniess()
        {
            AppBusniessFinanceBusniess appBusniessFinanceBusniess = new AppBusniessFinanceBusniess();

            BusniessDetails busniessDetails = new BusniessDetails { CompanyBusniessName = "" };
            List<KeyPrincipals> keyPrincipals = new List<KeyPrincipals>()
            {
                //new KeyPrincipals{Title = "",FirstName = ""}
            };
            List<BusniessLiabilities> busniessLiabilities = new List<BusniessLiabilities>()
            {
                //new BusniessLiabilities{Lender="", OrigionalLoanAmount=0} 
            };
            List<Serviceability> serviceability = new List<Serviceability>()
            {
                //new Serviceability{ Year=(DateTime.Now.Year).ToString(),TurnOver=0}
            };
            BusniessDocuments busniessDocuments = new BusniessDocuments { DocumentName = "" };

            appBusniessFinanceBusniess.busniessDetails = busniessDetails;
            appBusniessFinanceBusniess.keyPrincipals = keyPrincipals;
            appBusniessFinanceBusniess.busniessLiabilities = busniessLiabilities;
            appBusniessFinanceBusniess.serviceability = serviceability;
            appBusniessFinanceBusniess.busniessDocuments = busniessDocuments;

            _appBusniessFinanceBusniessRepository.Add(appBusniessFinanceBusniess);           
            
            AppBusniessFinance appBusniessFinance = _appBusniessFinanceRepository.GetAppBusniessFinance_appBusniessFinance(appID); 
            appBusniessFinance.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
            appBusniessFinance.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);
        }
        public ViewResult DeleteBusniess(int id)
        {
            _appBusniessFinanceBusniessRepository.Delete(id);

            AppBusniessFinance appBusniessFinance = _appBusniessFinanceRepository.GetAppBusniessFinance_appBusniessFinance(appID);
            appBusniessFinance.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
            appBusniessFinance.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);

        }
        public IActionResult EditBusniess(int id)
        {
            BusniessID = id;
            return RedirectToAction("BusniessDetails", "BusniessDetails");
        }
        public IActionResult AddIndividual()
        {
            AppBusniessFinanceIndividual appBusniessFinanceIndividual = new AppBusniessFinanceIndividual();

            PersonalDetails individualPersonalDetails = new PersonalDetails { FirstName = "" };
            AddressDetails IndividualAddressDetails = new AddressDetails { City = "" };
            EmploymentDetails IndividualEmploymentDetails = new EmploymentDetails { EmployersName = "" };
            MonthlyIncome monthlyIncome = new MonthlyIncome { DividendsAfterTax = 0 };
            MonthlyExpenditure monthlyExpenditure = new MonthlyExpenditure { CarInsuranceRoadTax = 0 };
            Asset asset = new Asset { Cash = 654 };
            Liabilities liabilities = new Liabilities { NetAssets = 0 };
            List<PropertySchedule> _propertySchedule = new List<PropertySchedule>()
            {
                //new PropertySchedule{ Owner="", PropertyAddress=""}
            };
            CreditHistory creditHistory = new CreditHistory { CriminalConvictions = "" };
            IndividualDocuments individualDocuments = new IndividualDocuments { DocumentName = "" };


            appBusniessFinanceIndividual.personalDetails = individualPersonalDetails;
            appBusniessFinanceIndividual.addressDetails = IndividualAddressDetails;
            appBusniessFinanceIndividual.employmentDetails = IndividualEmploymentDetails;
            appBusniessFinanceIndividual.monthlyIncome = monthlyIncome;
            appBusniessFinanceIndividual.monthlyExpenditure = monthlyExpenditure;
            appBusniessFinanceIndividual.asset = asset;
            appBusniessFinanceIndividual.liabilities = liabilities;
            appBusniessFinanceIndividual.propertySchedule = _propertySchedule;
            appBusniessFinanceIndividual.creditHistory = creditHistory;
            appBusniessFinanceIndividual.individualDocuments = individualDocuments;

            _appBusniessFinanceIndividualRepository.Add(appBusniessFinanceIndividual);

            AppBusniessFinance appBusniessFinance = _appBusniessFinanceRepository.GetAppBusniessFinance_appBusniessFinance(appID);
            appBusniessFinance.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
            appBusniessFinance.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);
        }
        public ViewResult DeleteIndividual(int id)
        {
            _appBusniessFinanceIndividualRepository.Delete(id);

            AppBusniessFinance appBusniessFinance = _appBusniessFinanceRepository.GetAppBusniessFinance_appBusniessFinance(appID);
            appBusniessFinance.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
            appBusniessFinance.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);
        }
        public IActionResult EditIndividual(int id)
        {
            IndividualID = id;
            return RedirectToAction("PersonalDetails", "IndividualPersonalDetails");
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

            AppBusniessFinance appBusniessFinance = _appBusniessFinanceRepository.GetAppBusniessFinance_appBusniessFinance(appID);
            appBusniessFinance.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
            appBusniessFinance.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);
            //AppBusniessFinance appBusniessFinance = new AppBusniessFinance();
            //appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            //return View("AppBusniessFinance", appBusniessFinance);
        }
        [HttpGet]
        public IActionResult EditSecurityDetail(int id)
        {
            AppBusniessFinanceSecurityDetails securityDetails = _appBusniessFinanceSecurityDetails.GetAppBusniessFinanceSecurityDetails(id);
            return PartialView("_EditSecurityDetailBusniessPartialView", securityDetails);
        }
        [HttpPost]
        public IActionResult EditSecurityDetail(AppBusniessFinanceSecurityDetails appBusniessFinanceSecurityDetailsChanges)
        {
            _appBusniessFinanceSecurityDetails.Update(appBusniessFinanceSecurityDetailsChanges);

            AppBusniessFinance appBusniessFinance = _appBusniessFinanceRepository.GetAppBusniessFinance_appBusniessFinance(appID);
            appBusniessFinance.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
            appBusniessFinance.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppBusniessFinance", appBusniessFinance);
            //AppBusniessFinance appBusniessFinance = new AppBusniessFinance();
            //appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            //return View("AppBusniessFinance", appBusniessFinance);
            //return View();
        }
        public ViewResult DeleteSecurityDetail(int id)
        {
            _appBusniessFinanceSecurityDetails.Delete(id);

            AppBusniessFinance appBusniessFinance = _appBusniessFinanceRepository.GetAppBusniessFinance_appBusniessFinance(appID);
            appBusniessFinance.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
            appBusniessFinance.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
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
        }
        [HttpPost]
        public IActionResult AppBusniessFinance(AppBusniessFinance appBusniessFinance)
        {
            appBusniessFinance.busniesses = (List<AppBusniessFinanceBusniess>)_appBusniessFinanceBusniessRepository.GetAllBusniess();
            appBusniessFinance.individuals = (List<AppBusniessFinanceIndividual>)_appBusniessFinanceIndividualRepository.GetAllIndividual();
            appBusniessFinance.securityDetails = (List<AppBusniessFinanceSecurityDetails>)_appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            appBusniessFinance.Lead = lead;
            //Update App As a Whole Application            
            AppBusniessFinance appBusniessFinance1 = _appBusniessFinanceRepository.Update(appBusniessFinance);
            return RedirectToAction("AllApplications", "Home");

        }
    }
}
