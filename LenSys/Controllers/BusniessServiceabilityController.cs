using LenSys.Models.BusniessServiceability;
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

        public BusniessServiceabilityController(IServiceabilityRepository serviceabilityRepository)
        {
            _serviceabilityRepository = serviceabilityRepository;
        }
        public ViewResult Index()
        {
            var model = _serviceabilityRepository.GetAllServiceability();
            return View("AllServiceability", model);
            //return View("Serviceability");
        }

        public ViewResult AllServiceability()
        {
            var model = _serviceabilityRepository.GetAllServiceability();
            return View("AllServiceability", model);
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

                return RedirectToAction("AllServiceability", updatedServiceability);
            }

            return View("AllServiceability");
        }
        public ViewResult DeleteServiceability(int id)
        {
            _serviceabilityRepository.Delete(id);
            var RemainingServiceability = _serviceabilityRepository.GetAllServiceability();
            return View("AllServiceability", RemainingServiceability);
        }


        [HttpGet]
        public ViewResult Serviceability()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Serviceability(Serviceability serviceability)
        {
            if (ModelState.IsValid)
            {
                Serviceability serviceability1 = _serviceabilityRepository.Add(serviceability);

                var updatedServiceability = _serviceabilityRepository.GetAllServiceability();
                return RedirectToAction("AllServiceability", updatedServiceability);
            }

            return View();
        }
    }
}
