using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.BusniessDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessDetailsController:Controller
    {
        private IAppAssetFinanceBusniessRepository _appAssetFinanceBusniessRepository;
        public BusniessDetailsController(IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository)
        {
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("BusniessDetails");
        }
        [HttpGet]
        public ViewResult BusniessDetails()
        {
            BusniessDetails busniessDetails;
            int BusniessId = AppAssetFinanceController.BusniessID;
            if ( BusniessId == 0)
            {
                busniessDetails = new BusniessDetails();
            }

             busniessDetails = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;

            return View(busniessDetails);
            //return View();
        }
        [HttpPost]
        public IActionResult BusniessDetails(BusniessDetails busniessDetails)
        {
            int id = AppAssetFinanceController.appID;
            int BusniessId = AppAssetFinanceController.BusniessID;

            AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);

            //if (ModelState.IsValid)
            {
                appAssetFinanceBusniess.busniessDetails = busniessDetails;
                return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            }
        }
    }
}
