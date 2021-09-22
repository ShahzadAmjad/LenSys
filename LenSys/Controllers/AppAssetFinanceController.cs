using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
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
            appAssetFinanceBusniess.busniessDetails.CompanyBusniessName = "Temp";
            _appAssetFinanceBusniessRepository.Add(appAssetFinanceBusniess);


            //return RedirectToAction("BusniessDetails", "BusniessDetails");
            return View("AppAssetFinance");
        }
        public IActionResult AddIndividual()
        {

            //return RedirectToAction("PersonalDetails", "IndividualPersonalDetails");
            AppAssetFinanceIndividual appAssetFinanceIndividual = new AppAssetFinanceIndividual();

            PersonalDetails individualPersonalDetails = new PersonalDetails { FirstName = "Temp" };

            appAssetFinanceIndividual.personalDetails= individualPersonalDetails;
            _appAssetFinanceIndividualRepository.Add(appAssetFinanceIndividual);


            //return RedirectToAction("BusniessDetails", "BusniessDetails");
            return View("AppAssetFinance");
        }
        [HttpGet]
        public ViewResult AppAssetFinance()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AppAssetFinance(AppAssetFinance appAssetFinance)
        {
            if (ModelState.IsValid)
            {
                AppAssetFinance appAssetFinance1=_appAssetFinanceRepository.Add(appAssetFinance);

            }

             return View();
            //return JavaScript(alert(""));
        }


    }
}
