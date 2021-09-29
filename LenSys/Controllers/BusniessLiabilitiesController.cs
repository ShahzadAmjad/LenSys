using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
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
        public BusniessLiabilitiesController(IBusniessLiabilitiesRepository busniessLiabilitiesRepository, IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository)
        {
            _busniessLiabilitiesRepository = busniessLiabilitiesRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            int BusniessId = AppAssetFinanceController.BusniessID;
            if(BusniessId!=0)
            {
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                _busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);

            }


            var model = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();
            //return View("AllBusniessLiabilities", model);
            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
            viewmodel._busniessLiabilities = model;
            viewmodel.busniessLiabilities = new BusniessLiabilities();

            return View("AllBusniessLiabilities", viewmodel);
        }
        [HttpGet]
        public ViewResult AllBusniessLiabilities()
        {
            int BusniessId = AppAssetFinanceController.BusniessID;
            if (BusniessId != 0)
            {
                IEnumerable<BusniessLiabilities> busniessLiabilities = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessLiabilities;
                _busniessLiabilitiesRepository.SetBusniessLiabilitiesList(busniessLiabilities);

            }
            var model = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
            viewmodel._busniessLiabilities = model;
            viewmodel.busniessLiabilities = new BusniessLiabilities();

            return View("AllBusniessLiabilities", viewmodel);
        }
        [HttpPost]
        public IActionResult AllBusniessLiabilities(BusniessLiabilitiesCreateViewModel busniessLiabilitiesCreateViewModel )
        {
            if (ModelState.IsValid)
            {
                BusniessLiabilities busniessLiabilities1 = _busniessLiabilitiesRepository.Add(busniessLiabilitiesCreateViewModel.busniessLiabilities);

                var updatedbusniessLiabilities = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

                int BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;

                BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
                viewmodel._busniessLiabilities = updatedbusniessLiabilities;
                viewmodel.busniessLiabilities = new BusniessLiabilities();

                return RedirectToAction("AllBusniessLiabilities", viewmodel);
            }

            return View();
        }

        [HttpGet]
        public ViewResult EditBusniessLiabilities(int id)
        {
            BusniessLiabilities model = _busniessLiabilitiesRepository.GetBusniessLiabilities(id);
            ViewBag.PageTitle = "Edit Busniess Liabilities";

            return View("EditBusniessLiabilities", model);
        }
        [HttpPost]
        public IActionResult EditBusniessLiabilities(BusniessLiabilities busniessLiabilities)
        {
            if (ModelState.IsValid)
            {
                _busniessLiabilitiesRepository.Update(busniessLiabilities);

                var updatedBusniessLiabilities = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();


                //copy from personaldetail controler
                
                int BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedBusniessLiabilities;

                return RedirectToAction("AllBusniessLiabilities", updatedBusniessLiabilities);
            }

            return View();
        }
        public ViewResult DeleteBusniessLiabilities(int id)
        {
            _busniessLiabilitiesRepository.Delete(id);
            var updatedBusniessLiabilities = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

            int BusniessId = AppAssetFinanceController.BusniessID;
            AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedBusniessLiabilities;

            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
            viewmodel._busniessLiabilities = updatedBusniessLiabilities;
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
           // if (ModelState.IsValid)
            {
                BusniessLiabilities busniessLiabilities1 = _busniessLiabilitiesRepository.Add(busniessLiabilities);

                var updatedbusniessLiabilities= _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

                int BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.busniessLiabilities = (List<BusniessLiabilities>)updatedbusniessLiabilities;

                BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
                viewmodel._busniessLiabilities = updatedbusniessLiabilities;
                viewmodel.busniessLiabilities = new BusniessLiabilities();

                return RedirectToAction("AllBusniessLiabilities", viewmodel);
            }

            //return View();
        }
    }
}
