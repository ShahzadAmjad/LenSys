using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.BusniessDetails;
using LenSys.Models.IndividualPersonalDetails;
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
        public static int appID;
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
            return View("AppAssetFinance");
        }
        public IActionResult AddLead()
        {
            return RedirectToAction("Lead","Home");
        }
        public IActionResult AddBusniess()
        {
            AppAssetFinanceBusniess appAssetFinanceBusniess = new AppAssetFinanceBusniess();

            BusniessDetails busniessDetails = new BusniessDetails { CompanyBusniessName = "Temp" };
            appAssetFinanceBusniess.busniessDetails=busniessDetails;
             _appAssetFinanceBusniessRepository.Add(appAssetFinanceBusniess);

            AppAssetFinance appAssetFinance = _appAssetFinanceRepository.GetAppAssetFinance(appID); //new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            return View("AppAssetFinance", appAssetFinance);
            //return RedirectToAction("BusniessDetails", "BusniessDetails");
            //return View("AppAssetFinance");
        }
        public IActionResult AddIndividual()
        {

            //return RedirectToAction("PersonalDetails", "IndividualPersonalDetails");
            AppAssetFinanceIndividual appAssetFinanceIndividual = new AppAssetFinanceIndividual();
            PersonalDetails individualPersonalDetails = new PersonalDetails { FirstName = "Temp" };
            appAssetFinanceIndividual.personalDetails= individualPersonalDetails;
            _appAssetFinanceIndividualRepository.Add(appAssetFinanceIndividual);



            AppAssetFinance appAssetFinance = _appAssetFinanceRepository.GetAppAssetFinance(appID); //new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();
           
            return View("AppAssetFinance", appAssetFinance);
            //return RedirectToAction("BusniessDetails", "BusniessDetails");
            //return View("AppAssetFinance");
        }
        [HttpGet]
        public ViewResult AppAssetFinance(int id)
        {
            //Saving to global id
            appID = id;

            AppAssetFinance AppAssetFinanceApplication = _appAssetFinanceRepository.GetAppAssetFinance(id);
            _appAssetFinanceBusniessRepository.SetBusniessList(AppAssetFinanceApplication.busniesses);
            _appAssetFinanceIndividualRepository.SetIndividualList(AppAssetFinanceApplication.individuals);
            
            //Fetched from db in Future
            //AppAssetFinanceApplication.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            //AppAssetFinanceApplication.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();


            //AppAssetFinance appAssetFinance = new AppAssetFinance();
            //appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            //appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            //return View("AppAssetFinance", appAssetFinance);

            //return View();
            return View("AppAssetFinance", AppAssetFinanceApplication);
        }

        //Update AppAssetFinance
        [HttpPost]
        public IActionResult AppAssetFinance(AppAssetFinance appAssetFinance)
        {
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();


            //if (ModelState.IsValid)
            //{
                AppAssetFinance appAssetFinance1=_appAssetFinanceRepository.Update(appAssetFinance);

            //}

            //AppAssetFinance 
            //appAssetFinance = new AppAssetFinance();
            //appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.ClearIndividualList();
            //appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.ClearBusniessList();
            
            //appAssetFinance.securityDetails = List;
            //return View("AppBusniessFinance", appBusniessFinance2);

            //return View("AppAssetFinance", appAssetFinance);

            return RedirectToAction("AllApplications", "Home");
            //return JavaScript(alert(""));
        }


    }
}
