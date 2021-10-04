using LenSys.Models;
using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
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
    public class AppAssetFinanceController : Controller
    {
        private IAppAssetFinanceRepository _appAssetFinanceRepository;
        private IAppAssetFinanceBusniessRepository _appAssetFinanceBusniessRepository;
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        //Shared Variables
        public static int appID;
        public static int IndividualID;
        public static int BusniessID;

        public static Lead lead;
        public AppAssetFinanceController(IAppAssetFinanceRepository appAssetFinanceRepository, IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository, IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceRepository = appAssetFinanceRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View();
        }
        public IActionResult AddLead()
        {
            return RedirectToAction("Lead","Home");
        }
        public IActionResult AddBusniess()
        {
            AppAssetFinanceBusniess appAssetFinanceBusniess = new AppAssetFinanceBusniess();

            BusniessDetails busniessDetails = new BusniessDetails { CompanyBusniessName = "" };
            List<KeyPrincipals> keyPrincipals =new List<KeyPrincipals>()
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
            BusniessDocuments busniessDocuments = new BusniessDocuments { DocumentName="" };

            appAssetFinanceBusniess.busniessDetails=busniessDetails;
            appAssetFinanceBusniess.keyPrincipals = keyPrincipals;
            appAssetFinanceBusniess.busniessLiabilities = busniessLiabilities;
            appAssetFinanceBusniess.serviceability = serviceability;
            appAssetFinanceBusniess.busniessDocuments = busniessDocuments;

            _appAssetFinanceBusniessRepository.Add(appAssetFinanceBusniess);

            AppAssetFinance appAssetFinance = _appAssetFinanceRepository.GetAppAssetFinance(appID); //new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            return View("AppAssetFinance", appAssetFinance);
            //return RedirectToAction("BusniessDetails", "BusniessDetails");
            //return View("AppAssetFinance");
        }
        public ViewResult DeleteBusniess(int id)
        {
            _appAssetFinanceBusniessRepository.Delete(id);

            AppAssetFinance appAssetFinance = _appAssetFinanceRepository.GetAppAssetFinance(appID); //new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            return View("AppAssetFinance", appAssetFinance);

        }
        public IActionResult EditBusniess(int id)
        {
            BusniessID = id;

            return RedirectToAction("BusniessDetails", "BusniessDetails");
            //, new { id = id }
        }
        public IActionResult AddIndividual()
        {     
            AppAssetFinanceIndividual appAssetFinanceIndividual = new AppAssetFinanceIndividual();
            PersonalDetails individualPersonalDetails = new PersonalDetails { FirstName = "" };
            AddressDetails IndividualAddressDetails = new AddressDetails { City = "" };
            EmploymentDetails IndividualEmploymentDetails = new EmploymentDetails { EmployersName = "" };
            MonthlyIncome monthlyIncome = new MonthlyIncome { DividendsAfterTax = 0 };
            MonthlyExpenditure monthlyExpenditure = new MonthlyExpenditure {CarInsuranceRoadTax=0 };
            Asset asset = new Asset { Cash = 654 };
            Liabilities liabilities = new Liabilities { NetAssets = 0 };
            List<PropertySchedule> _propertySchedule= new List<PropertySchedule>()
            {
                //new PropertySchedule{Owner="", PropertyAddress=""}
            };
            CreditHistory creditHistory = new CreditHistory { CriminalConvictions = "" };
            IndividualDocuments individualDocuments = new IndividualDocuments { DocumentName = "" };
                 
            appAssetFinanceIndividual.personalDetails= individualPersonalDetails;
            appAssetFinanceIndividual.addressDetails = IndividualAddressDetails;
            appAssetFinanceIndividual.employmentDetails = IndividualEmploymentDetails;
            appAssetFinanceIndividual.monthlyIncome = monthlyIncome;
            appAssetFinanceIndividual.monthlyExpenditure = monthlyExpenditure;
            appAssetFinanceIndividual.asset = asset;
            appAssetFinanceIndividual.liabilities = liabilities;
            appAssetFinanceIndividual.propertySchedule = _propertySchedule;
            appAssetFinanceIndividual.creditHistory = creditHistory;
            appAssetFinanceIndividual.individualDocuments = individualDocuments;

            _appAssetFinanceIndividualRepository.Add(appAssetFinanceIndividual);



            AppAssetFinance appAssetFinance = _appAssetFinanceRepository.GetAppAssetFinance(appID); //new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();
           
            return View("AppAssetFinance", appAssetFinance);
            //return RedirectToAction("BusniessDetails", "BusniessDetails");
            //return View("AppAssetFinance");
        }
        public ViewResult DeleteIndividual(int id)
        {
            _appAssetFinanceIndividualRepository.Delete(id);

            AppAssetFinance appAssetFinance = _appAssetFinanceRepository.GetAppAssetFinance(appID); //new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            return View("AppAssetFinance", appAssetFinance);
        }
        public IActionResult EditIndividual(int id)
        {
            IndividualID = id;
             
            return RedirectToAction("PersonalDetails", "IndividualPersonalDetails");
            //, new { id = id }
        }
        [HttpGet]
        public ViewResult AppAssetFinance()
        {
            AppAssetFinance AppAssetFinanceApplication;
            //Saving to global variables
            appID = HomeController.EditAssetFinanceAppID; 

            if(appID==0)
            {
                AppAssetFinanceApplication = new AppAssetFinance();
            }
            else
            {
                AppAssetFinanceApplication = _appAssetFinanceRepository.GetAppAssetFinance(appID);
                AppAssetFinanceApplication.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
                AppAssetFinanceApplication.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();
                //Saving to global variables
                lead = AppAssetFinanceApplication.Lead;
            }

            return View("AppAssetFinance", AppAssetFinanceApplication);
        }
        //Update AppAssetFinance
        [HttpPost]
        public IActionResult AppAssetFinance(AppAssetFinance appAssetFinance)
        {
            foreach (AppAssetFinanceIndividual individual in _appAssetFinanceIndividualRepository.GetAllIndividual())
            {
                individual.IndividualId = 0;
                individual.personalDetails.PersonalDetailsId = 0;
                individual.addressDetails.AddressDetailsId = 0;
                individual.employmentDetails.EmploymentDetailsId = 0;
                individual.monthlyIncome.MonthlyIncomeId = 0;
                individual.monthlyExpenditure.MonthlyExpenditureId = 0;
                individual.asset.AssetId = 0;
                individual.liabilities.LiabilitiesId = 0;
                foreach (PropertySchedule property in individual.propertySchedule)
                {
                    property.PropertyId = 0;
                }
                individual.creditHistory.CreditHistoryId = 0;
                individual.individualDocuments.DocumentId = 0;
            }

            foreach (AppAssetFinanceBusniess busniess in _appAssetFinanceBusniessRepository.GetAllBusniess())
            {
                busniess.BusniessId = 0;
                busniess.busniessDetails.BusniessDetailsId = 0;
                foreach (KeyPrincipals keyPrincipal in busniess.keyPrincipals)
                {
                    keyPrincipal.KeyPrincipalsId = 0;
                }
                foreach (BusniessLiabilities liabilities in busniess.busniessLiabilities)
                {
                    liabilities.BusniessLiabilityId = 0;
                }
                foreach (Serviceability serviceability in busniess.serviceability)
                {
                    serviceability.ServiceabilityId = 0;
                }

                busniess.busniessDocuments.DocumentId = 0;
            }

            lead.LeadId = 0;
            appAssetFinance.AssetFinId = 0;

            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            appAssetFinance.Lead = lead;


            //Delete Old Record and add new one due to List multiple not updated
            // _appAssetFinanceRepository.Delete(appID);            
            //AppAssetFinance appAssetFinance1=_appAssetFinanceRepository.Add(appAssetFinance);

            AppAssetFinance appAssetFinance1 = _appAssetFinanceRepository.Update(appAssetFinance);

            //lead = new Lead();

            return RedirectToAction("AllApplications", "Home");
            //return JavaScript(alert(""));
        }
    }
}
