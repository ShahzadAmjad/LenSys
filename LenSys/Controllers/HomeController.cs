using LenSys.Models;
using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
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
        private IAppDevelopmentFinanceBusniessRepository _appDevelopmentFinanceBusniessRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        private IAppBusniessFinanceBusniessRepository _appBusniessFinanceBusniessRepository;
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppPropertyFinanceBusniessRepository _appPropertyFinanceBusniessRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;

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
            IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository, 
            IAppDevelopmentFinanceBusniessRepository appDevelopmentFinanceBusniessRepository, 
            IAppDevelopmentFinanceIndividualRepository appDevelopmentFinanceIndividualRepository, 
            IAppBusniessFinanceBusniessRepository appBusniessFinanceBusniessRepository,
            IAppBusniessFinanceIndividualRepository appBusniessFinanceIndividualRepository,
            IAppPropertyFinanceBusniessRepository appPropertyFinanceBusniessRepository, 
            IAppPropertyFinanceIndividualRepository appPropertyFinanceIndividualRepository)
        {
            this._allApplicationsRepository = allApplicationsRepository;
            _appAssetFinanceRepository = appAssetFinanceRepository;
            _appBusniessFinanceRepository = appBusniessFinanceRepository;
            _appDevelopmentFinanceRepository = appDevelopmentFinanceRepository;
            _appPropertyFinanceRepository = appPropertyFinanceRepository;
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
            _appDevelopmentFinanceBusniessRepository = appDevelopmentFinanceBusniessRepository;
            _appDevelopmentFinanceIndividualRepository = appDevelopmentFinanceIndividualRepository;
            _appBusniessFinanceBusniessRepository = appBusniessFinanceBusniessRepository;
            _appBusniessFinanceIndividualRepository = appBusniessFinanceIndividualRepository;
            _appPropertyFinanceBusniessRepository = appPropertyFinanceBusniessRepository;
            _appPropertyFinanceIndividualRepository = appPropertyFinanceIndividualRepository;
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
            var allApplicationsConcat = _allApplicationsRepository.GetAllApplications();
            AllApplications EditAppObj = allApplicationsConcat.ToList()[id];
            int deleteAppId = 0;

            if (EditAppObj.Type == "Asset finance")
            {
                deleteAppId = EditAppObj.AppID;
                _appAssetFinanceRepository.Delete(deleteAppId);
            }
            else if (EditAppObj.Type == "Business finance")
            {
                deleteAppId = EditAppObj.AppID;
                _appBusniessFinanceRepository.Delete(deleteAppId);
            }
            else if (EditAppObj.Type == "Development finance")
            {
                deleteAppId = EditAppObj.AppID;
                _appDevelopmentFinanceRepository.Delete(deleteAppId);
            }
            else if (EditAppObj.Type == "Property finance")
            {
                deleteAppId = EditAppObj.AppID;
                _appPropertyFinanceRepository.Delete(deleteAppId);
            }



            allApplicationsConcat = _allApplicationsRepository.GetAllApplications();
            return View("AllApplications", allApplicationsConcat);
        }
        public IActionResult EditApplication(int id)
        {
            var allApplicationsConcat = _allApplicationsRepository.GetAllApplications();
            AllApplications EditAppObj = allApplicationsConcat.ToList()[id];
            int EditAppObjId = EditAppObj.AppID;


            if (EditAppObj.Type == "Asset finance")
            {
                EditAssetFinanceAppID = EditAppObj.AppID;
                _appAssetFinanceBusniessRepository.SetBusniessList(_appAssetFinanceRepository.GetAppAssetFinance_EditHome(EditAppObjId).busniesses);
                _appAssetFinanceIndividualRepository.SetIndividualList(_appAssetFinanceRepository.GetAppAssetFinance_EditHome(EditAppObjId).individuals);
                return RedirectToAction("AppAssetFinance", "AppAssetFinance");
            }
            else if (EditAppObj.Type == "Business finance")
            {
                EditBusinessFinanceAppID = EditAppObj.AppID;
                _appBusniessFinanceBusniessRepository.SetBusniessList(_appBusniessFinanceRepository.GetAppBusniessFinance_EditHome(EditAppObjId).busniesses);
                _appBusniessFinanceIndividualRepository.SetIndividualList(_appBusniessFinanceRepository.GetAppBusniessFinance_EditHome(EditAppObjId).individuals);

                return RedirectToAction("AppBusniessFinance", "AppBusniessFinance");
            }
            else if (EditAppObj.Type == "Development finance")
            {
                EditDevelopmentFinanceAppID = EditAppObj.AppID;
                _appDevelopmentFinanceBusniessRepository.SetBusniessList(_appDevelopmentFinanceRepository.GetAppDevelopmentFinance_EditHome(EditAppObjId).busniesses);
                _appDevelopmentFinanceIndividualRepository.SetIndividualList(_appDevelopmentFinanceRepository.GetAppDevelopmentFinance_EditHome(EditAppObjId).individuals);

                return RedirectToAction("AppDevelopmentFinance", "AppDevelopmentFinance");
            }
            else if (EditAppObj.Type == "Property finance")
            {
                EditPropertyFinanceAppID = EditAppObj.AppID;
                _appPropertyFinanceBusniessRepository.SetBusniessList(_appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId).busniesses);
                _appPropertyFinanceIndividualRepository.SetIndividualList(_appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId).individuals);

                return RedirectToAction("AppPropertyFinance", "AppPropertyFinance");
            }
            else
            {               
                return View("AllApplications", allApplicationsConcat);
            }         
        }
    }
}
