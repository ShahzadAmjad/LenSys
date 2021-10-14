using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess;
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
        private IAppBusniessFinanceBusniessRepository _appBusniessFinanceBusniessRepository;
        private IAppDevelopmentFinanceBusniessRepository _appDevelopmentFinanceBusniessRepository;
        private IAppPropertyFinanceBusniessRepository _appPropertyFinanceBusniessRepository;
        public BusniessDetailsController(IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository,
            IAppBusniessFinanceBusniessRepository appBusniessFinanceBusniessRepository,
            IAppDevelopmentFinanceBusniessRepository appDevelopmentFinanceBusniessRepository,
            IAppPropertyFinanceBusniessRepository appPropertyFinanceBusniessRepository)
        {
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
            _appBusniessFinanceBusniessRepository = appBusniessFinanceBusniessRepository;
            _appDevelopmentFinanceBusniessRepository = appDevelopmentFinanceBusniessRepository;
            _appPropertyFinanceBusniessRepository = appPropertyFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            BusniessDetails busniessDetails;
            int BusniessId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                busniessDetails = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                busniessDetails = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                busniessDetails = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                busniessDetails = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }
            else
            {
                busniessDetails = new BusniessDetails();
            }           
            return View("BusniessDetails",busniessDetails);
        }
        [HttpGet]
        public ViewResult BusniessDetails()
        {
            BusniessDetails busniessDetails;
            int BusniessId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                busniessDetails = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                busniessDetails = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                busniessDetails = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                busniessDetails = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails;
            }
            else
            {
                busniessDetails = new BusniessDetails();
            }
            return View(busniessDetails);
        }
        [HttpPost]
        public IActionResult BusniessDetails(BusniessDetails busniessDetails)
        {
            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.busniessDetails = busniessDetails;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails= busniessDetails;
            }
            else if (editAppType == "Business finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails = busniessDetails;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails = busniessDetails;

            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).busniessDetails = busniessDetails;
            }
            return View(busniessDetails);
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
