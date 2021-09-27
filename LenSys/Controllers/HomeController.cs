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
            var appAssetFinanceApplication = _allApplicationsRepository.GetAllAssetFinanceApplication();
            return View("AllApplications", appAssetFinanceApplication);
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
                    AppAssetFinance appAssetFinance = new AppAssetFinance { CompanyName=lead.CompanyBusniessName , ApplicationType=lead.LoanPurpose};

                    
                    appAssetFinance.Lead = lead;
                    _appAssetFinanceRepository.Add(appAssetFinance);

                }

                else if (lead.LoanPurpose == "Business finance")
                {
                    AppBusniessFinance appBusniessFinance = new AppBusniessFinance();

                    appBusniessFinance.Lead = lead;
                    _appBusniessFinanceRepository.Add(appBusniessFinance);

                }
                else if (lead.LoanPurpose == "Development finance")
                {
                    AppDevelopmentFinance appDevelopmentFinance = new AppDevelopmentFinance();

                    appDevelopmentFinance.Lead = lead;
                    _appDevelopmentFinanceRepository.Add(appDevelopmentFinance);

                }
                else if (lead.LoanPurpose == "Property finance")
                {
                    AppPropertyFinance appPropertyFinance = new AppPropertyFinance();

                    appPropertyFinance.Lead = lead;
                    _appPropertyFinanceRepository.Add(appPropertyFinance);

                }
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                //return View("Lead");

                var appAssetFinanceApplication = _allApplicationsRepository.GetAllAssetFinanceApplication();
                return View("AllApplications", appAssetFinanceApplication);
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
            var appAssetFinanceApplication=_allApplicationsRepository.GetAllAssetFinanceApplication();
            //var model = _allApplicationsRepository.GetAllApplications();
            //return View(model);

            return View(appAssetFinanceApplication);
        }
        public ViewResult DeleteApplication(int id)
        {
            _allApplicationsRepository.DeleteAssetFinanceApplication(id);
            var RemainingApplications = _allApplicationsRepository.GetAllAssetFinanceApplication();
            
            return View("AllApplications", RemainingApplications);
        }
        public IActionResult EditApplication(int id)
        {
            //AppAssetFinance AppAssetFinanceApplication = _allApplicationsRepository.GetAssetFinanceApplication(id);

            //AppAssetFinanceApplication.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            //AppAssetFinanceApplication.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();




            //AllApplications application = _allApplicationsRepository.GetApplication(id);

            //if(application.FinanceType=="Asset Finance")
            //{
            //    return View("AppAssetFinance", "AppAssetFinance");
            //}
            //else if (application.FinanceType == "Busniess Finance")
            //{
            //    return View("AppBusniessFinance", "AppBusniessFinance");
            //}
            //else if (application.FinanceType == "Development Finace")
            //{
            //    return View("AppDevelopmentFinance", "AppDevelopmentFinance");
            //}
            //else if (application.FinanceType == "Property Finace")
            //{
            //    return View("AppPropertyFinance", "AppPropertyFinance");
            //}

            //return View("AllApplications");

            return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
        }

        

    }
}
