using LenSys.Models.AppDevelopmentFinance;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
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
        public IActionResult AddBusniess()
        {
            AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = new AppDevelopmentFinanceBusniess();

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

            appDevelopmentFinanceBusniess.busniessDetails = busniessDetails;
            appDevelopmentFinanceBusniess.keyPrincipals = keyPrincipals;
            appDevelopmentFinanceBusniess.busniessLiabilities = busniessLiabilities;
            appDevelopmentFinanceBusniess.serviceability = serviceability;
            appDevelopmentFinanceBusniess.busniessDocuments = busniessDocuments;

            _appDevelopmentFinanceBusniessRepository.Add(appDevelopmentFinanceBusniess);
            
            AppDevelopmentFinance appDevelopmentFinance = _appDevelopmentFinanceRepository.GetAppDevelopmentFinance_appDevelopmentFinance(appID);
            appDevelopmentFinance.busniesses = (List<AppDevelopmentFinanceBusniess>)_appDevelopmentFinanceBusniessRepository.GetAllBusniess();
            appDevelopmentFinance.individuals = (List<AppDevelopmentFinanceIndividual>)_appDevelopmentFinanceIndividualRepository.GetAllIndividual();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance", appDevelopmentFinance);
        }
        public ViewResult DeleteBusniess(int id)
        {
            _appDevelopmentFinanceBusniessRepository.Delete(id);

            AppDevelopmentFinance appDevelopmentFinance = _appDevelopmentFinanceRepository.GetAppDevelopmentFinance_appDevelopmentFinance(appID);
            appDevelopmentFinance.busniesses = (List<AppDevelopmentFinanceBusniess>)_appDevelopmentFinanceBusniessRepository.GetAllBusniess();
            appDevelopmentFinance.individuals = (List<AppDevelopmentFinanceIndividual>)_appDevelopmentFinanceIndividualRepository.GetAllIndividual();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance", appDevelopmentFinance);
        }
        public IActionResult EditBusniess(int id)
        {
            BusniessID = id;
            return RedirectToAction("BusniessDetails", "BusniessDetails");
        }
        public IActionResult AddIndividual()
        {
            AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = new AppDevelopmentFinanceIndividual();

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


            appDevelopmentFinanceIndividual.personalDetails = individualPersonalDetails;
            appDevelopmentFinanceIndividual.addressDetails = IndividualAddressDetails;
            appDevelopmentFinanceIndividual.employmentDetails = IndividualEmploymentDetails;
            appDevelopmentFinanceIndividual.monthlyIncome = monthlyIncome;
            appDevelopmentFinanceIndividual.monthlyExpenditure = monthlyExpenditure;
            appDevelopmentFinanceIndividual.asset = asset;
            appDevelopmentFinanceIndividual.liabilities = liabilities;
            appDevelopmentFinanceIndividual.propertySchedule = _propertySchedule;
            appDevelopmentFinanceIndividual.creditHistory = creditHistory;
            appDevelopmentFinanceIndividual.individualDocuments = individualDocuments;

            _appDevelopmentFinanceIndividualRepository.Add(appDevelopmentFinanceIndividual);

            AppDevelopmentFinance appDevelopmentFinance = _appDevelopmentFinanceRepository.GetAppDevelopmentFinance_appDevelopmentFinance(appID);
            appDevelopmentFinance.busniesses = (List<AppDevelopmentFinanceBusniess>)_appDevelopmentFinanceBusniessRepository.GetAllBusniess();
            appDevelopmentFinance.individuals = (List<AppDevelopmentFinanceIndividual>)_appDevelopmentFinanceIndividualRepository.GetAllIndividual();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance", appDevelopmentFinance);
        }
        public ViewResult DeleteIndividual(int id)
        {
            _appDevelopmentFinanceIndividualRepository.Delete(id);

            AppDevelopmentFinance appDevelopmentFinance = _appDevelopmentFinanceRepository.GetAppDevelopmentFinance_appDevelopmentFinance(appID);
            appDevelopmentFinance.busniesses = (List<AppDevelopmentFinanceBusniess>)_appDevelopmentFinanceBusniessRepository.GetAllBusniess();
            appDevelopmentFinance.individuals = (List<AppDevelopmentFinanceIndividual>)_appDevelopmentFinanceIndividualRepository.GetAllIndividual();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance", appDevelopmentFinance);
        }
        public IActionResult EditIndividual(int id)
        {
            IndividualID = id;
            return RedirectToAction("PersonalDetails", "IndividualPersonalDetails");
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
            AppDevelopmentFinance appDevelopmentFinance = _appDevelopmentFinanceRepository.GetAppDevelopmentFinance_appDevelopmentFinance(appID);
            appDevelopmentFinance.busniesses = (List<AppDevelopmentFinanceBusniess>)_appDevelopmentFinanceBusniessRepository.GetAllBusniess();
            appDevelopmentFinance.individuals = (List<AppDevelopmentFinanceIndividual>)_appDevelopmentFinanceIndividualRepository.GetAllIndividual();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance", appDevelopmentFinance);

            //AppDevelopmentFinance appDevelopmentFinance = new AppDevelopmentFinance();
            //appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            //return View("AppDevelopmentFinance", appDevelopmentFinance);
        }

        [HttpGet]
        public IActionResult EditSecurityDetail(int id)
        {
            AppDevelopmentFinanceSecurityDetails securityDetails = _appDevelopmentFinanceSecurityDetails.GetAppDevelopmentFinanceSecurityDetails(id);
            return PartialView("_EditSecurityDetailDevelopmentPartialView", securityDetails);
        }

        [HttpPost]
        public IActionResult EditSecurityDetail(AppDevelopmentFinanceSecurityDetails appDevelopmentFinanceSecurityDetailsChanges)
        {
            _appDevelopmentFinanceSecurityDetails.Update(appDevelopmentFinanceSecurityDetailsChanges);

            AppDevelopmentFinance appDevelopmentFinance = _appDevelopmentFinanceRepository.GetAppDevelopmentFinance_appDevelopmentFinance(appID);
            appDevelopmentFinance.busniesses = (List<AppDevelopmentFinanceBusniess>)_appDevelopmentFinanceBusniessRepository.GetAllBusniess();
            appDevelopmentFinance.individuals = (List<AppDevelopmentFinanceIndividual>)_appDevelopmentFinanceIndividualRepository.GetAllIndividual();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance", appDevelopmentFinance);
        }

        public ViewResult DeleteSecurityDetail(int id)
        {
            _appDevelopmentFinanceSecurityDetails.Delete(id);
            AppDevelopmentFinance appDevelopmentFinance = _appDevelopmentFinanceRepository.GetAppDevelopmentFinance_appDevelopmentFinance(appID);
            appDevelopmentFinance.busniesses = (List<AppDevelopmentFinanceBusniess>)_appDevelopmentFinanceBusniessRepository.GetAllBusniess();
            appDevelopmentFinance.individuals = (List<AppDevelopmentFinanceIndividual>)_appDevelopmentFinanceIndividualRepository.GetAllIndividual();
            appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            return View("AppDevelopmentFinance", appDevelopmentFinance);
            //AppDevelopmentFinance appDevelopmentFinance = new AppDevelopmentFinance();
            //appDevelopmentFinance.securityDetails = (List<AppDevelopmentFinanceSecurityDetails>)_appDevelopmentFinanceSecurityDetails.GetAllAppDevelopmentFinanceSecurityDetails();
            //return View("AppDevelopmentFinance", appDevelopmentFinance);
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
