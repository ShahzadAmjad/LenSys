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
            BusniessDetails busniessDetails;
            int BusniessId = AppAssetFinanceController.BusniessID;
            if (BusniessId == 0)
            {
                busniessDetails = new BusniessDetails();
            }
            else
            {
                busniessDetails = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }

            return View("BusniessDetails",busniessDetails);
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
            else
            {
                busniessDetails = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }

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
                //return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
                return View();
            }
        }
        public IActionResult ReturnToParentApp()
        {
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                return RedirectToAction("AppAssetFinance", "AppAssetFinance");
            }

            else if (editAppType == "Business finance")
            {
                return RedirectToAction("AppBusniessFinance", "AppBusniessFinance");
            }
            else if (editAppType == "Development finance")
            {
                return RedirectToAction("AppDevelopmentFinance", "AppDevelopmentFinance");
            }
            else if (editAppType == "Property finance")
            {
                return RedirectToAction("AppPropertyFinance", "AppPropertyFinance");
            }
            else
            {
                return View("BusniessDetails");
            }
        }
    }
}
