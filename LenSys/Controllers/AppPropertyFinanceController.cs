using LenSys.Models.AppPropertyFinance;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
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
        public IActionResult AddBusniess()
        {
            AppPropertyFinanceBusniess appPropertyFinanceBusniess = new AppPropertyFinanceBusniess();

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

            appPropertyFinanceBusniess.busniessDetails = busniessDetails;
            appPropertyFinanceBusniess.keyPrincipals = keyPrincipals;
            appPropertyFinanceBusniess.busniessLiabilities = busniessLiabilities;
            appPropertyFinanceBusniess.serviceability = serviceability;
            appPropertyFinanceBusniess.busniessDocuments = busniessDocuments;

            _appPropertyFinanceBusniessRepository.Add(appPropertyFinanceBusniess);

            AppPropertyFinance appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_appPropertyFinance(appID);           
            appPropertyFinance.busniesses = (List<AppPropertyFinanceBusniess>)_appPropertyFinanceBusniessRepository.GetAllBusniess();
            appPropertyFinance.individuals = (List<AppPropertyFinanceIndividual>)_appPropertyFinanceIndividualRepository.GetAllIndividual();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            return View("AppPropertyFinance", appPropertyFinance);
        }
        public ViewResult DeleteBusniess(int id)
        {
            _appPropertyFinanceBusniessRepository.Delete(id);

            AppPropertyFinance appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_appPropertyFinance(appID);
            appPropertyFinance.busniesses = (List<AppPropertyFinanceBusniess>)_appPropertyFinanceBusniessRepository.GetAllBusniess();
            appPropertyFinance.individuals = (List<AppPropertyFinanceIndividual>)_appPropertyFinanceIndividualRepository.GetAllIndividual();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            return View("AppPropertyFinance", appPropertyFinance);
        }
        public IActionResult EditBusniess(int id)
        {
            BusniessID = id;
            return RedirectToAction("BusniessDetails", "BusniessDetails");
        }
        public IActionResult AddIndividual()
        {
            AppPropertyFinanceIndividual appPropertyFinanceIndividual = new AppPropertyFinanceIndividual();

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

            appPropertyFinanceIndividual.personalDetails = individualPersonalDetails;
            appPropertyFinanceIndividual.addressDetails = IndividualAddressDetails;
            appPropertyFinanceIndividual.employmentDetails = IndividualEmploymentDetails;
            appPropertyFinanceIndividual.monthlyIncome = monthlyIncome;
            appPropertyFinanceIndividual.monthlyExpenditure = monthlyExpenditure;
            appPropertyFinanceIndividual.asset = asset;
            appPropertyFinanceIndividual.liabilities = liabilities;
            appPropertyFinanceIndividual.propertySchedule = _propertySchedule;
            appPropertyFinanceIndividual.creditHistory = creditHistory;
            appPropertyFinanceIndividual.individualDocuments = individualDocuments;

            _appPropertyFinanceIndividualRepository.Add(appPropertyFinanceIndividual);

            AppPropertyFinance appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_appPropertyFinance(appID);
            appPropertyFinance.busniesses = (List<AppPropertyFinanceBusniess>)_appPropertyFinanceBusniessRepository.GetAllBusniess();
            appPropertyFinance.individuals = (List<AppPropertyFinanceIndividual>)_appPropertyFinanceIndividualRepository.GetAllIndividual();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            return View("AppPropertyFinance", appPropertyFinance);
        }
        public ViewResult DeleteIndividual(int id)
        {
            _appPropertyFinanceIndividualRepository.Delete(id);

            AppPropertyFinance appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_appPropertyFinance(appID);
            appPropertyFinance.busniesses = (List<AppPropertyFinanceBusniess>)_appPropertyFinanceBusniessRepository.GetAllBusniess();
            appPropertyFinance.individuals = (List<AppPropertyFinanceIndividual>)_appPropertyFinanceIndividualRepository.GetAllIndividual();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            return View("AppPropertyFinance", appPropertyFinance);
        }
        public IActionResult EditIndividual(int id)
        {
            IndividualID = id;
            return RedirectToAction("PersonalDetails", "IndividualPersonalDetails");
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
            AppPropertyFinance appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_appPropertyFinance(appID);
            appPropertyFinance.busniesses = (List<AppPropertyFinanceBusniess>)_appPropertyFinanceBusniessRepository.GetAllBusniess();
            appPropertyFinance.individuals = (List<AppPropertyFinanceIndividual>)_appPropertyFinanceIndividualRepository.GetAllIndividual();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            return View("AppPropertyFinance", appPropertyFinance);
            //AppPropertyFinance appPropertyFinance = new AppPropertyFinance();
            //appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            //return View("AppPropertyFinance", appPropertyFinance);
        }
        [HttpGet]
        public IActionResult EditSecurityDetail(int id)
        {
            AppPropertyFinanceSecurityDetails securityDetails = _appPropertyFinanceSecurityDetails.GetAppPropertysFinanceSecurityDetails(id);          
            return PartialView("_EditSecurityDetailPropertyPartialView", securityDetails);
            //return View("EditSecurityDetail",model);
        }
        [HttpPost]
        public IActionResult EditSecurityDetail(AppPropertyFinanceSecurityDetails appPropertyFinanceSecurityDetailsChanges)
        {
            _appPropertyFinanceSecurityDetails.Update(appPropertyFinanceSecurityDetailsChanges);

            AppPropertyFinance appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_appPropertyFinance(appID);
            appPropertyFinance.busniesses = (List<AppPropertyFinanceBusniess>)_appPropertyFinanceBusniessRepository.GetAllBusniess();
            appPropertyFinance.individuals = (List<AppPropertyFinanceIndividual>)_appPropertyFinanceIndividualRepository.GetAllIndividual();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            return View("AppPropertyFinance", appPropertyFinance);
        }
        public ViewResult DeleteSecurityDetail(int id)
        {
            _appPropertyFinanceSecurityDetails.Delete(id);
            AppPropertyFinance appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_appPropertyFinance(appID);
            appPropertyFinance.busniesses = (List<AppPropertyFinanceBusniess>)_appPropertyFinanceBusniessRepository.GetAllBusniess();
            appPropertyFinance.individuals = (List<AppPropertyFinanceIndividual>)_appPropertyFinanceIndividualRepository.GetAllIndividual();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            return View("AppPropertyFinance", appPropertyFinance);
        }
        [HttpGet]
        public ViewResult AppPropertyFinance()
        {
            AppPropertyFinance appPropertyFinance;           
            //Saving to global variables
            appID = HomeController.EditPropertyFinanceAppID;

            if (appID == 0)
            {
                appPropertyFinance = new AppPropertyFinance();
            }
            else
            {
                appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_appPropertyFinance(appID);
                appPropertyFinance.busniesses = (List<AppPropertyFinanceBusniess>)_appPropertyFinanceBusniessRepository.GetAllBusniess();
                appPropertyFinance.individuals = (List<AppPropertyFinanceIndividual>)_appPropertyFinanceIndividualRepository.GetAllIndividual();
                appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
                //Saving to global variables
                lead = appPropertyFinance.Lead;
            }        
            return View("AppPropertyFinance", appPropertyFinance);
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
