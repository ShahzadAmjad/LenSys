using LenSys.Models;
using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.BusniessDetails;
using LenSys.Models.Home;
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
        public static int IndividualID;

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
        public ViewResult DeleteBusniess(int id)
        {
            _appAssetFinanceBusniessRepository.Delete(id);

            AppAssetFinance appAssetFinance = _appAssetFinanceRepository.GetAppAssetFinance(appID); //new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            return View("AppAssetFinance", appAssetFinance);

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
        public ViewResult DeleteIndividual(int id)
        {
            _appAssetFinanceIndividualRepository.Delete(id);

            AppAssetFinance appAssetFinance = _appAssetFinanceRepository.GetAppAssetFinance(appID); //new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            return View("AppAssetFinance", appAssetFinance);
        }
        public IActionResult AddIndividualPersonalDetails(int id)
        {
            //AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(individualId);
            ////PersonalDetails individualPersonalDetails = appAssetFinanceIndividual.personalDetails;
            //int individualPersonalDetailsId = appAssetFinanceIndividual.personalDetails.PersonalDetailsId;

            //return View();

            IndividualID = id;
            //SiteGlobalVariables._IndividualId = id;
            return RedirectToAction("PersonalDetails", "IndividualPersonalDetails");
            //, new { id = id }
        }

        [HttpGet]
        public ViewResult AppAssetFinance(int id)
        {
            //Saving to global variables
            appID = id;
            

            AppAssetFinance AppAssetFinanceApplication = _appAssetFinanceRepository.GetAppAssetFinance(id);
            //_appAssetFinanceBusniessRepository.SetBusniessList(AppAssetFinanceApplication.busniesses);
            //_appAssetFinanceIndividualRepository.SetIndividualList(AppAssetFinanceApplication.individuals);

            //Saving to global variables
            lead = AppAssetFinanceApplication.Lead;
           
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
            }

            foreach (AppAssetFinanceBusniess busniess in _appAssetFinanceBusniessRepository.GetAllBusniess())
            {
                busniess.BusniessId = 0;
                busniess.busniessDetails.BusniessDetailsId = 0;
            }

            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            lead.LeadId = 0;
            appAssetFinance.Lead = lead;

            //if (ModelState.IsValid)
            //{
            _appAssetFinanceRepository.Delete(appID);

            appAssetFinance.AssetFinId = 0;
            AppAssetFinance appAssetFinance1=_appAssetFinanceRepository.Add(appAssetFinance);
            lead = new Lead();

            //AppAssetFinance appAssetFinance1=_appAssetFinanceRepository.Update(appAssetFinance);



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
