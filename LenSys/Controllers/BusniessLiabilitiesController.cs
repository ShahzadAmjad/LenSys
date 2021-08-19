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
        public BusniessLiabilitiesController(IBusniessLiabilitiesRepository busniessLiabilitiesRepository)
        {
            _busniessLiabilitiesRepository = busniessLiabilitiesRepository;
        }
        public ViewResult Index()
        {
            var model = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();
            return View("AllBusniessLiabilities", model);
            //return View("BusniessLiabilities");
        }
        public ViewResult AllBusniessLiabilities()
        {
            var model = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();

            BusniessLiabilitiesCreateViewModel viewmodel = new BusniessLiabilitiesCreateViewModel();
            viewmodel._busniessLiabilities = model;
            viewmodel.busniessLiabilities = new BusniessLiabilities();

            return View("AllBusniessLiabilities", viewmodel);
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

                return RedirectToAction("AllBusniessLiabilities", updatedBusniessLiabilities);
            }

            return View();
        }
        public ViewResult DeleteBusniessLiabilities(int id)
        {
            _busniessLiabilitiesRepository.Delete(id);
            var RemainingBusniessLiabilities = _busniessLiabilitiesRepository.GetAllBusniessLiabilities();
            return View("AllBusniessLiabilities", RemainingBusniessLiabilities);
        }
        [HttpGet]
        public ViewResult BusniessLiabilities()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BusniessLiabilities(BusniessLiabilities busniessLiabilities)
        {
            if (ModelState.IsValid)
            {
                BusniessLiabilities busniessLiabilities1 = _busniessLiabilitiesRepository.Add(busniessLiabilities);

                var updatedbusniessLiabilities= _busniessLiabilitiesRepository.GetAllBusniessLiabilities();
                return RedirectToAction("AllBusniessLiabilities", updatedbusniessLiabilities);
            }

            return View();
        }
    }
}
