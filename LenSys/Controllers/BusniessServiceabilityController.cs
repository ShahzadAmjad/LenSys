using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess;
using LenSys.Models.BusniessServiceability;
using LenSys.ViewModels.BusniessServiceability;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessServiceabilityController:Controller
    {
        private IServiceabilityRepository _serviceabilityRepository;
        private IAppAssetFinanceBusniessRepository _appAssetFinanceBusniessRepository;
        private IAppBusniessFinanceBusniessRepository _appBusniessFinanceBusniessRepository;
        private IAppDevelopmentFinanceBusniessRepository _appDevelopmentFinanceBusniessRepository;
        private IAppPropertyFinanceBusniessRepository _appPropertyFinanceBusniessRepository;
        public BusniessServiceabilityController(IServiceabilityRepository serviceabilityRepository,
            IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository,
            IAppBusniessFinanceBusniessRepository appBusniessFinanceBusniessRepository,
            IAppDevelopmentFinanceBusniessRepository appDevelopmentFinanceBusniessRepository,
            IAppPropertyFinanceBusniessRepository appPropertyFinanceBusniessRepository)
        {
            _serviceabilityRepository = serviceabilityRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
            _appBusniessFinanceBusniessRepository = appBusniessFinanceBusniessRepository;
            _appDevelopmentFinanceBusniessRepository = appDevelopmentFinanceBusniessRepository;
            _appPropertyFinanceBusniessRepository = appPropertyFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            //int BusniessId = AppAssetFinanceController.BusniessID;
            //if (BusniessId != 0)
            //{
            //    IEnumerable<Serviceability> serviceabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
            //    _serviceabilityRepository.SetServiceabilityList(serviceabilities);

            //}
            //var model = _serviceabilityRepository.GetAllServiceability();
            int BusniessId;
            var model = new List<Serviceability>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                IEnumerable<Serviceability> serviceabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                model= (List<Serviceability>)_serviceabilityRepository.SetServiceabilityList(serviceabilities);
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                IEnumerable<Serviceability> serviceabilities = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                model = (List<Serviceability>)_serviceabilityRepository.SetServiceabilityList(serviceabilities);
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                IEnumerable<Serviceability> serviceabilities = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                model = (List<Serviceability>)_serviceabilityRepository.SetServiceabilityList(serviceabilities);
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                IEnumerable<Serviceability> serviceabilities = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                model = (List<Serviceability>)_serviceabilityRepository.SetServiceabilityList(serviceabilities);
            }
            else
            {
                model = new List<Serviceability>();
            }

            ServiceabilityCreateViewModel viewmodel = new ServiceabilityCreateViewModel();
            viewmodel._serviceability = model;
            viewmodel.serviceability = new Serviceability();
            return View("AllServiceability", viewmodel);
        }
        public ViewResult AllServiceability()
        {
            //int BusniessId = AppAssetFinanceController.BusniessID;
            //if (BusniessId != 0)
            //{
            //    IEnumerable<Serviceability> serviceabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
            //    _serviceabilityRepository.SetServiceabilityList(serviceabilities);

            //}
            //var model = _serviceabilityRepository.GetAllServiceability();
            int BusniessId;
            var model = new List<Serviceability>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                IEnumerable<Serviceability> serviceabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                model = (List<Serviceability>)_serviceabilityRepository.SetServiceabilityList(serviceabilities);
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                IEnumerable<Serviceability> serviceabilities = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                model = (List<Serviceability>)_serviceabilityRepository.SetServiceabilityList(serviceabilities);
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                IEnumerable<Serviceability> serviceabilities = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                model = (List<Serviceability>)_serviceabilityRepository.SetServiceabilityList(serviceabilities);
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                IEnumerable<Serviceability> serviceabilities = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                model = (List<Serviceability>)_serviceabilityRepository.SetServiceabilityList(serviceabilities);
            }
            else
            {
                model = new List<Serviceability>();
            }
            ServiceabilityCreateViewModel viewmodel = new ServiceabilityCreateViewModel();
            viewmodel._serviceability = model;
            viewmodel.serviceability = new Serviceability();


            return View("AllServiceability", viewmodel);
        }
        [HttpGet]
        public IActionResult AddServiceability()
        {
            Serviceability serviceability = new Serviceability();
            return PartialView("_AddBusniessServiceabilityPartialView", serviceability);
        }
        [HttpPost]
        public IActionResult AddServiceability(Serviceability serviceability)
        {
            Serviceability serviceability1 = _serviceabilityRepository.Add(serviceability);
            var updatedServiceability = _serviceabilityRepository.GetAllServiceability();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusniessFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusniessFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }

            ServiceabilityCreateViewModel viewmodel = new ServiceabilityCreateViewModel();
            viewmodel._serviceability = updatedServiceability;
            viewmodel.serviceability = new Serviceability();
            return RedirectToAction("AllServiceability", viewmodel);
        }
        [HttpGet]
        public ViewResult EditServiceability(int id)
        {
            Serviceability model = _serviceabilityRepository.GetServiceability(id);
            return View("EditServiceability", model);
        }
        [HttpPost]
        public IActionResult EditServiceability(Serviceability serviceability)
        {
            _serviceabilityRepository.Update(serviceability);
            var updatedServiceability = _serviceabilityRepository.GetAllServiceability();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;

            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusniessFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusniessFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }
            ServiceabilityCreateViewModel viewmodel = new ServiceabilityCreateViewModel();
            viewmodel._serviceability = updatedServiceability;
            viewmodel.serviceability = new Serviceability();

            return RedirectToAction("AllServiceability", viewmodel);

        }
        public ViewResult DeleteServiceability(int id)
        {
            _serviceabilityRepository.Delete(id);
            var updatedServiceability = _serviceabilityRepository.GetAllServiceability();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.serviceability = (List<Serviceability>)RemainingServiceability;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusniessFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusniessFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }

            ServiceabilityCreateViewModel viewmodel = new ServiceabilityCreateViewModel();
            viewmodel._serviceability = updatedServiceability;
            viewmodel.serviceability = new Serviceability();
            return View("AllServiceability", viewmodel);
        }
        [HttpGet]
        public ViewResult Serviceability()
        {
            return View();
        }
        //For External View
        [HttpPost]
        public IActionResult Serviceability(Serviceability serviceability)
        {
            Serviceability serviceability1 = _serviceabilityRepository.Add(serviceability);
            var updatedServiceability = _serviceabilityRepository.GetAllServiceability();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusniessFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusniessFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;
            }

            ServiceabilityCreateViewModel viewmodel = new ServiceabilityCreateViewModel();
            viewmodel._serviceability = updatedServiceability;
            viewmodel.serviceability = new Serviceability();
            return View("AllServiceability", viewmodel);
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
                return View("AllServiceability");
            }
        }
    }
}
