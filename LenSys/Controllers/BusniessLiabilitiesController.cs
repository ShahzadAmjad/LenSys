using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess;
using LenSys.Models.BusniessLiabilities;
using LenSys.ViewModels.BusniessLiabilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessLiabilitiesController:Controller
    {
        private IBusniessLiabilitiesRepository _busniessLiabilitiesRepository;
        private IAppAssetFinanceBusniessRepository _appAssetFinanceBusniessRepository;
        private IAppBusniessFinanceBusniessRepository _appBusniessFinanceBusniessRepository;
        private IAppDevelopmentFinanceBusniessRepository _appDevelopmentFinanceBusniessRepository;
        private IAppPropertyFinanceBusniessRepository _appPropertyFinanceBusniessRepository;
        public BusniessLiabilitiesController(IBusniessLiabilitiesRepository busniessLiabilitiesRepository,
            IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository,
            IAppBusniessFinanceBusniessRepository appBusniessFinanceBusniessRepository,
            IAppDevelopmentFinanceBusniessRepository appDevelopmentFinanceBusniessRepository,
            IAppPropertyFinanceBusniessRepository appPropertyFinanceBusniessRepository)
        {
            _busniessLiabilitiesRepository = busniessLiabilitiesRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
            _appBusniessFinanceBusniessRepository = appBusniessFinanceBusniessRepository;
            _appDevelopmentFinanceBusniessRepository = appDevelopmentFinanceBusniessRepository;
            _appPropertyFinanceBusniessRepository = appPropertyFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            //int BusniessId = AppAssetFinanceController.BusniessID;
            //if(BusniessId!=0)
            //{
            //    IEnumerable<BusniessLiabilities> busniessLiabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
            //    _busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);

            //}
            //var model = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();
            int BusniessId;
            var model = new List<BusniessLiabilities>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                model = (List<BusniessLiabilities>)_busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                model = (List<BusniessLiabilities>)_busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                model = (List<BusniessLiabilities>)_busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                model = (List<BusniessLiabilities>)_busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);
            }
            else
            {
                model = new List<BusniessLiabilities>();
            }


            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
            viewmodel._busniessLiabilities = model;
            viewmodel.busniessLiabilities = new BusniessLiabilities();

            return View("AllBusniessLiabilities", viewmodel);
        }
        [HttpGet]
        public ViewResult AllBusniessLiabilities()
        {
            //int BusniessId = AppAssetFinanceController.BusniessID;
            //if (BusniessId != 0)
            //{
            //    IEnumerable<BusniessLiabilities> busniessLiabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
            //    _busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);

            //}
            //var model = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();
            int BusniessId;
            var model = new List<BusniessLiabilities>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                model = (List<BusniessLiabilities>)_busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                model = (List<BusniessLiabilities>)_busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                model = (List<BusniessLiabilities>)_busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                model = (List<BusniessLiabilities>)_busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);
            }
            else
            {
                model = new List<BusniessLiabilities>();
            }

            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
            viewmodel._busniessLiabilities = model;
            viewmodel.busniessLiabilities = new BusniessLiabilities();

            return View("AllBusniessLiabilities", viewmodel);
        }
        [HttpPost]
        public IActionResult AllBusniessLiabilities(BusniessLiabilitiesCreateViewModel busniessLiabilitiesCreateViewModel )
        {

            BusniessLiabilities busniessLiabilities1 = _busniessLiabilitiesRepository.Add(busniessLiabilitiesCreateViewModel.busniessLiabilities);
            var updatedbusniessLiabilities = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusniesFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusniesFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }

            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
            viewmodel._busniessLiabilities = updatedbusniessLiabilities;
            viewmodel.busniessLiabilities = new BusniessLiabilities();
            return RedirectToAction("AllBusniessLiabilities", viewmodel);
           
        }
        [HttpGet]
        public IActionResult AddBusniessLiabilities()
        {
            BusniessLiabilities busniessLiabilities = new BusniessLiabilities();
            return PartialView("_AddBusniessLiabilitiesPartialView", busniessLiabilities);
        }
        [HttpPost]
        public IActionResult AddBusniessLiabilities(BusniessLiabilities busniessLiabilities)
        {
           
                BusniessLiabilities busniessLiabilities1 = _busniessLiabilitiesRepository.Add(busniessLiabilities);
                var updatedbusniessLiabilities = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusniesFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusniesFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }

            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
                viewmodel._busniessLiabilities = updatedbusniessLiabilities;
                viewmodel.busniessLiabilities = new BusniessLiabilities();
                return RedirectToAction("AllBusniessLiabilities", viewmodel);
        }
        [HttpGet]
        public ViewResult EditBusniessLiabilities(int id)
        {
            BusniessLiabilities model = _busniessLiabilitiesRepository.GetBusniessLiabilities(id);
            return View("EditBusniessLiabilities", model);
        }
        [HttpPost]
        public IActionResult EditBusniessLiabilities(BusniessLiabilities busniessLiabilities)
        {
            _busniessLiabilitiesRepository.Update(busniessLiabilities);
            var updatedbusniessLiabilities = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedBusniessLiabilities;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusniesFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusniesFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
            viewmodel._busniessLiabilities = updatedbusniessLiabilities;
            viewmodel.busniessLiabilities = new BusniessLiabilities();
            return RedirectToAction("AllBusniessLiabilities", viewmodel);
        }
        public ViewResult DeleteBusniessLiabilities(int id)
        {
            _busniessLiabilitiesRepository.Delete(id);
            var updatedbusniessLiabilities = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedBusniessLiabilities;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusniesFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusniesFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }

            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
            viewmodel._busniessLiabilities = updatedbusniessLiabilities;
            viewmodel.busniessLiabilities = new BusniessLiabilities();

            return View("AllBusniessLiabilities", viewmodel);
        }
        [HttpGet]
        public ViewResult BusniessLiabilities()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BusniessLiabilities(BusniessLiabilities busniessLiabilities)
        {
                BusniessLiabilities busniessLiabilities1 = _busniessLiabilitiesRepository.Add(busniessLiabilities);
                var updatedbusniessLiabilities= _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusniesFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusniesFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;
            }

            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
                viewmodel._busniessLiabilities = updatedbusniessLiabilities;
                viewmodel.busniessLiabilities = new BusniessLiabilities();
                return RedirectToAction("AllBusniessLiabilities", viewmodel);

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
                return View("AllBusniessLiabilities");
            }
        }
    }
}
