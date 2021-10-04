using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
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

        public BusniessServiceabilityController(IServiceabilityRepository serviceabilityRepository, IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository)
        {
            _serviceabilityRepository = serviceabilityRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            int BusniessId = AppAssetFinanceController.BusniessID;
            if (BusniessId != 0)
            {
                IEnumerable<Serviceability> serviceabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                _serviceabilityRepository.SetServiceabilityList(serviceabilities);

            }

            var model = _serviceabilityRepository.GetAllServiceability();
            //return View("AllServiceability", model);
            ServiceabilityCreateViewModel viewmodel = new ServiceabilityCreateViewModel();
            viewmodel._serviceability = model;
            viewmodel.serviceability = new Serviceability();


            return View("AllServiceability", viewmodel);
        }
        public ViewResult AllServiceability()
        {

            int BusniessId = AppAssetFinanceController.BusniessID;
            if (BusniessId != 0)
            {
                IEnumerable<Serviceability> serviceabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).serviceability;
                _serviceabilityRepository.SetServiceabilityList(serviceabilities);

            }
            var model = _serviceabilityRepository.GetAllServiceability();

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
            //if (ModelState.IsValid)
            {
                Serviceability serviceability1 = _serviceabilityRepository.Add(serviceability);

                var updatedServiceability = _serviceabilityRepository.GetAllServiceability();

                int BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;

                ServiceabilityCreateViewModel viewmodel = new ServiceabilityCreateViewModel();
                viewmodel._serviceability = updatedServiceability;
                viewmodel.serviceability = new Serviceability();

                return RedirectToAction("AllServiceability", viewmodel);
            }

            //return View();
        }

        [HttpGet]
        public ViewResult EditServiceability(int id)
        {
            Serviceability model = _serviceabilityRepository.GetServiceability(id);
            ViewBag.PageTitle = "Edit Serviceability";

            return View("EditServiceability", model);
        }
        [HttpPost]
        public IActionResult EditServiceability(Serviceability serviceability)
        {
            if (ModelState.IsValid)
            {
                _serviceabilityRepository.Update(serviceability);

                var updatedServiceability = _serviceabilityRepository.GetAllServiceability();

                int BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;


                return RedirectToAction("AllServiceability", updatedServiceability);
            }

            return View("AllServiceability");
        }
        public ViewResult DeleteServiceability(int id)
        {
            _serviceabilityRepository.Delete(id);
            var RemainingServiceability = _serviceabilityRepository.GetAllServiceability();

            int BusniessId = AppAssetFinanceController.BusniessID;
            AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            appAssetFinanceBusniess.serviceability = (List<Serviceability>)RemainingServiceability;

            ServiceabilityCreateViewModel viewmodel = new ServiceabilityCreateViewModel();
            viewmodel._serviceability = RemainingServiceability;
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
            if (ModelState.IsValid)
            {
                Serviceability serviceability1 = _serviceabilityRepository.Add(serviceability);

                var updatedServiceability = _serviceabilityRepository.GetAllServiceability();

                int BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.serviceability = (List<Serviceability>)updatedServiceability;

                return RedirectToAction("AllServiceability", updatedServiceability);
            }

            return View();
        }
    }
}
