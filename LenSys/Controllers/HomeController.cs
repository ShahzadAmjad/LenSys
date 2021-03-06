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
using LenSys.Models.Home.Lead;
using LenSys.Models.Home.AllApplications;
using LenSys.Models.Home.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LenSys.Models.Home;

namespace LenSys.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAllApplicationsRepository _allApplicationsRepository;
        private ILeadRepository _leadRepository;
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

        private IAppBusniessFinanceSecurityDetailsRepository _appBusniessFinanceSecurityDetailsRepository;
        private IAppDevelopmentFinanceSecurityDetailsRepository _appDevelopmentFinanceSecurityDetailsRepository;
        private IAppPropertyFinanceSecurityDetailsRepository _appPropertyFinanceSecurityDetailsRepository;

        public static int EditAssetFinanceAppID;
        public static int EditBusinessFinanceAppID;
        public static int EditDevelopmentFinanceAppID;
        public static int EditPropertyFinanceAppID;
        public static string EditAppType;
        public static bool EditAppBySearch=false;
        public static Search GloabalSearch;


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
            IAppPropertyFinanceIndividualRepository appPropertyFinanceIndividualRepository,
            IAppBusniessFinanceSecurityDetailsRepository appBusniessFinanceSecurityDetailsRepository,
            IAppDevelopmentFinanceSecurityDetailsRepository appDevelopmentFinanceSecurityDetailsRepository,
            IAppPropertyFinanceSecurityDetailsRepository appPropertyFinanceSecurityDetailsRepository, ILeadRepository leadRepository)
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
            _appBusniessFinanceSecurityDetailsRepository = appBusniessFinanceSecurityDetailsRepository;
            _appDevelopmentFinanceSecurityDetailsRepository = appDevelopmentFinanceSecurityDetailsRepository;
            _appPropertyFinanceSecurityDetailsRepository = appPropertyFinanceSecurityDetailsRepository;
            _leadRepository = leadRepository;
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
            //_leadRepository.Add(lead);
            //if (ModelState.IsValid)
            {
                if (lead.LoanPurpose == "Asset finance")
                {
                    AppAssetFinance appAssetFinance = new AppAssetFinance { CompanyName = lead.CompanyBusniessName };

                    appAssetFinance.Lead = lead;
                    _appAssetFinanceRepository.Add(appAssetFinance);
                }

                else if (lead.LoanPurpose == "Business finance")
                {
                    AppBusniessFinance appBusniessFinance = new AppBusniessFinance { AccountantCompany = lead.CompanyBusniessName };

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
        [HttpGet]
        public ViewResult Search()
        {
            Search search = new Search();
            search.SearchAttribute = "Lead Id";
            //search.SearchParam = "0";
            return View("Search", search);
        }
        [HttpPost]
        public IActionResult Search(Search search)
        {
            //setting the global variable for delete and edit return functions
            GloabalSearch = search;

            if (search.SearchAttribute == null || search.SearchAttribute == "")
            {
                search.SearchAttribute = "Application Id";
            }
            if (search.SearchParam == null || search.SearchParam == "")
            {
                search.SearchParam = "0";
            }
            var SearchallApplications = _allApplicationsRepository.SearchAllApplications(search.SearchAttribute, search.SearchParam);

            return View("SearchResults", SearchallApplications);
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
        public IActionResult SearchResults()
        {
            if (GloabalSearch.SearchAttribute == null || GloabalSearch.SearchAttribute == "")
            {
                GloabalSearch.SearchAttribute = "Application Id";
            }
            if (GloabalSearch.SearchParam == null || GloabalSearch.SearchParam == "")
            {
                GloabalSearch.SearchParam = "0";
            }
            var SearchallApplications = _allApplicationsRepository.SearchAllApplications(GloabalSearch.SearchAttribute, GloabalSearch.SearchParam);
            return View("SearchResults", SearchallApplications);
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
        public ViewResult DeleteApplication_Search(int id)
        {
            var SearchallApplications = _allApplicationsRepository.SearchAllApplications(GloabalSearch.SearchAttribute, GloabalSearch.SearchParam);
            AllApplications EditAppObj = SearchallApplications.ToList()[id];
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

            //allApplicationsConcat = _allApplicationsRepository.GetAllApplications();
            //return View("AllApplications", allApplicationsConcat);
            if (GloabalSearch.SearchAttribute == null || GloabalSearch.SearchAttribute == "")
            {
                GloabalSearch.SearchAttribute = "Application Id";
            }
            if (GloabalSearch.SearchParam == null || GloabalSearch.SearchParam == "")
            {
                GloabalSearch.SearchParam = "0";
            }
            var UpdatedSearchallApplications = _allApplicationsRepository.SearchAllApplications(GloabalSearch.SearchAttribute, GloabalSearch.SearchParam);
            return View("SearchResults", UpdatedSearchallApplications);
        }
        public IActionResult EditApplication(int id)
        {
            EditAppBySearch = false;
            var allApplicationsConcat = _allApplicationsRepository.GetAllApplications();
            AllApplications EditAppObj = allApplicationsConcat.ToList()[id];
            int EditAppObjId = EditAppObj.AppID;
            //To be used in individual and busniess
            EditAppType = EditAppObj.Type;

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
                _appBusniessFinanceSecurityDetailsRepository.SetSecurityDetailsList(_appBusniessFinanceRepository.GetAppBusniessFinance_EditHome(EditAppObjId).securityDetails);
                return RedirectToAction("AppBusniessFinance", "AppBusniessFinance");
            }
            else if (EditAppObj.Type == "Development finance")
            {
                EditDevelopmentFinanceAppID = EditAppObj.AppID;
                _appDevelopmentFinanceBusniessRepository.SetBusniessList(_appDevelopmentFinanceRepository.GetAppDevelopmentFinance_EditHome(EditAppObjId).busniesses);
                _appDevelopmentFinanceIndividualRepository.SetIndividualList(_appDevelopmentFinanceRepository.GetAppDevelopmentFinance_EditHome(EditAppObjId).individuals);
                _appDevelopmentFinanceSecurityDetailsRepository.SetSecurityDetailsList(_appDevelopmentFinanceRepository.GetAppDevelopmentFinance_EditHome(EditAppObjId).securityDetails);
                return RedirectToAction("AppDevelopmentFinance", "AppDevelopmentFinance");
            }
            else if (EditAppObj.Type == "Property finance")
            {
                EditPropertyFinanceAppID = EditAppObj.AppID;
                AppPropertyFinance appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId);
                _appPropertyFinanceBusniessRepository.SetBusniessList(_appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId).busniesses);
                _appPropertyFinanceIndividualRepository.SetIndividualList(_appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId).individuals);
                _appPropertyFinanceSecurityDetailsRepository.SetSecurityDetailsList(_appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId).securityDetails);
                return RedirectToAction("AppPropertyFinance", "AppPropertyFinance");
            }
            else
            {
                return View("AllApplications", allApplicationsConcat);
            }
        }
        public IActionResult EditApplication_Search(int id)
        {
            EditAppBySearch = true;
            var SearchallApplications = _allApplicationsRepository.SearchAllApplications(GloabalSearch.SearchAttribute, GloabalSearch.SearchParam);
            AllApplications EditAppObj = SearchallApplications.ToList()[id];
            int EditAppObjId = EditAppObj.AppID;
            //To be used in individual and busniess
            EditAppType = EditAppObj.Type;

            if (EditAppType == "Asset finance")
            {
                EditAssetFinanceAppID = EditAppObj.AppID;
                _appAssetFinanceBusniessRepository.SetBusniessList(_appAssetFinanceRepository.GetAppAssetFinance_EditHome(EditAppObjId).busniesses);
                _appAssetFinanceIndividualRepository.SetIndividualList(_appAssetFinanceRepository.GetAppAssetFinance_EditHome(EditAppObjId).individuals);
                return RedirectToAction("AppAssetFinance", "AppAssetFinance");
            }
            else if (EditAppType == "Business finance")
            {
                EditBusinessFinanceAppID = EditAppObj.AppID;
                _appBusniessFinanceBusniessRepository.SetBusniessList(_appBusniessFinanceRepository.GetAppBusniessFinance_EditHome(EditAppObjId).busniesses);
                _appBusniessFinanceIndividualRepository.SetIndividualList(_appBusniessFinanceRepository.GetAppBusniessFinance_EditHome(EditAppObjId).individuals);
                _appBusniessFinanceSecurityDetailsRepository.SetSecurityDetailsList(_appBusniessFinanceRepository.GetAppBusniessFinance_EditHome(EditAppObjId).securityDetails);
                return RedirectToAction("AppBusniessFinance", "AppBusniessFinance");
            }
            else if (EditAppType == "Development finance")
            {
                EditDevelopmentFinanceAppID = EditAppObj.AppID;
                _appDevelopmentFinanceBusniessRepository.SetBusniessList(_appDevelopmentFinanceRepository.GetAppDevelopmentFinance_EditHome(EditAppObjId).busniesses);
                _appDevelopmentFinanceIndividualRepository.SetIndividualList(_appDevelopmentFinanceRepository.GetAppDevelopmentFinance_EditHome(EditAppObjId).individuals);
                _appDevelopmentFinanceSecurityDetailsRepository.SetSecurityDetailsList(_appDevelopmentFinanceRepository.GetAppDevelopmentFinance_EditHome(EditAppObjId).securityDetails);
                return RedirectToAction("AppDevelopmentFinance", "AppDevelopmentFinance");
            }
            else if (EditAppType == "Property finance")
            {
                EditPropertyFinanceAppID = EditAppObj.AppID;
                AppPropertyFinance appPropertyFinance = _appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId);
                _appPropertyFinanceBusniessRepository.SetBusniessList(_appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId).busniesses);
                _appPropertyFinanceIndividualRepository.SetIndividualList(_appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId).individuals);
                _appPropertyFinanceSecurityDetailsRepository.SetSecurityDetailsList(_appPropertyFinanceRepository.GetAppPropertyFinance_EditHome(EditAppObjId).securityDetails);
                return RedirectToAction("AppPropertyFinance", "AppPropertyFinance");
            }
            else
            {
                return View("SearchResults", SearchallApplications);
            }
        }
        public IActionResult ViewApplication(int id)
        {
            var SearchallApplications = _allApplicationsRepository.SearchAllApplications(GloabalSearch.SearchAttribute, GloabalSearch.SearchParam);
            AllApplications EditAppObj = SearchallApplications.ToList()[id];
            int EditAppObjId = EditAppObj.AppID;
            //To be used in individual and busniess
            EditAppType = EditAppObj.Type;

            return View();
        }
        public IActionResult ViewApplication_Search(int id)
        {
            var SearchallApplications = _allApplicationsRepository.SearchAllApplications(GloabalSearch.SearchAttribute, GloabalSearch.SearchParam);
            AllApplications EditAppObj = SearchallApplications.ToList()[id];
            int EditAppObjId = EditAppObj.AppID;
            //To be used in individual and busniess
            EditAppType = EditAppObj.Type;

            return View();
        }
    }
}
