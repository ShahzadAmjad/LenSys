using LenSys.Models;
using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance;
using LenSys.Models.AppDevelopmentFinance;
using LenSys.Models.AppPropertyFinance;
using LenSys.Models.Home;
using LenSys.Models.Home.AllApplications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class HomeController: Controller
    {
        
        private readonly IAllApplicationsRepository _allApplicationsRepository;
        private IAppAssetFinanceRepository _appAssetFinanceRepository;
        private IAppBusniessFinanceRepository _appBusniessFinanceRepository;
        private IAppDevelopmentFinanceRepository _appDevelopmentFinanceRepository;
        private IAppPropertyFinanceRepository _appPropertyFinanceRepository;
        private IAppAssetFinanceBusniessRepository _appAssetFinanceBusniessRepository;
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        public static int EditAssetFinanceAppID;
        public static int EditBusinessFinanceAppID;
        public static int EditDevelopmentFinanceAppID;
        public static int EditPropertyFinanceAppID;
        public HomeController(IAllApplicationsRepository allApplicationsRepository,
            IAppAssetFinanceRepository appAssetFinanceRepository,
            IAppBusniessFinanceRepository appBusniessFinanceRepository,
            IAppDevelopmentFinanceRepository appDevelopmentFinanceRepository,
            IAppPropertyFinanceRepository appPropertyFinanceRepository, 
            IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository,
            IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository)
        {
            this._allApplicationsRepository = allApplicationsRepository;
            _appAssetFinanceRepository = appAssetFinanceRepository;
            _appBusniessFinanceRepository = appBusniessFinanceRepository;
            _appDevelopmentFinanceRepository = appDevelopmentFinanceRepository;
            _appPropertyFinanceRepository = appPropertyFinanceRepository;
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            //var appAssetFinanceApplication = _appAssetFinanceRepository.GetAllAppAssetFinance();
            //var appAssetFinanceApplication_AllAppFormat = _appAssetFinanceRepository.GetAllAppAssetFinance_AllApplication();
            var allApplicationsConcat = _allApplicationsRepository.GetAllApplications();
            //AllApplications app = appAssetFinanceApplication.FirstOrDefault();

            return View("AllApplications", allApplicationsConcat);

            //return View("AllApplications", appAssetFinanceApplication);
        }
        [HttpGet]
        public ViewResult Lead()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Lead(Lead lead)
        {
            //if (ModelState.IsValid)
            {
                if(lead.LoanPurpose=="Asset finance")
                {
                    AppAssetFinance appAssetFinance = new AppAssetFinance { CompanyName=lead.CompanyBusniessName };                    
                    
                    appAssetFinance.Lead = lead;
                    _appAssetFinanceRepository.Add(appAssetFinance);
                }

                else if (lead.LoanPurpose == "Business finance")
                {
                    AppBusniessFinance appBusniessFinance = new AppBusniessFinance{ AccountantCompany = lead.CompanyBusniessName };

                    appBusniessFinance.Lead = lead;
                    _appBusniessFinanceRepository.Add(appBusniessFinance);
                }
                else if (lead.LoanPurpose == "Development finance")
                {
                    AppDevelopmentFinance appDevelopmentFinance = new AppDevelopmentFinance { DetailsOfBuildersContrators = lead.CompanyBusniessName };

                    appDevelopmentFinance.Lead = lead;
                    _appDevelopmentFinanceRepository.Add(appDevelopmentFinance);

                }
                else if (lead.LoanPurpose == "Property finance")
                {
                    AppPropertyFinance appPropertyFinance = new AppPropertyFinance() { AccountantCompany = lead.CompanyBusniessName };

                    appPropertyFinance.Lead = lead;
                    _appPropertyFinanceRepository.Add(appPropertyFinance);
                }
                var allApplicationsConcat = _allApplicationsRepository.GetAllApplications();
                //var appAssetFinanceApplication = _appAssetFinanceRepository.GetAllAppAssetFinance();
                return View("AllApplications", allApplicationsConcat);
            }

            //return View("Lead");
        }
        public ViewResult Search()
        {
            return View();
        }
        public ViewResult DocumentList()
        {
            return View();
        }
        public ViewResult AllApplications()
        {           
            var allApplicationsConcat = _allApplicationsRepository.GetAllApplications();
            return View(allApplicationsConcat);
        }
        public ViewResult DeleteApplication(int id)
        {
            _appAssetFinanceRepository.Delete(id);
            var allApplicationsConcat = _allApplicationsRepository.GetAllApplications();
            return View("AllApplications", allApplicationsConcat);
        }
        public IActionResult EditApplication(int id)
        {
            EditAssetFinanceAppID = id;
            //AppAssetFinance AppAssetFinanceApplication = _appAssetFinanceRepository.GetAppAssetFinance_EditHome(id); //_allApplicationsRepository.GetAssetFinanceApplication(id);
            
            _appAssetFinanceBusniessRepository.SetBusniessList(_appAssetFinanceRepository.GetAppAssetFinance_EditHome(id).busniesses);
            _appAssetFinanceIndividualRepository.SetIndividualList(_appAssetFinanceRepository.GetAppAssetFinance_EditHome(id).individuals);
        
            return RedirectToAction("AppAssetFinance", "AppAssetFinance");
        }

    }
}
