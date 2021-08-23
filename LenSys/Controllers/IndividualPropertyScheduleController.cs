using LenSys.Models.IndividualPropertySchedule;
using LenSys.ViewModels.IndividualPropertySchedule;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualPropertyScheduleController:Controller
    {
        private IPropertyScheduleRepository _propertyScheduleRepositry;
        public IndividualPropertyScheduleController(IPropertyScheduleRepository propertyScheduleRepository)
        {
            _propertyScheduleRepositry = propertyScheduleRepository;
        }
        public ViewResult Index()
        {
            var model = _propertyScheduleRepositry.GetAllPropertySchedule();
            //return View("AllProperties",model);
            PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
            viewmodel._propertySchedule = model;
            viewmodel.propertySchedule = new PropertySchedule();

            return View("AllProperties", viewmodel);
        }
        [HttpGet]
        public ViewResult AllProperties()
        {
            var model = _propertyScheduleRepositry.GetAllPropertySchedule();
            //var tuple= new Tuple<ModelBinderAttribute,>
            PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
            viewmodel._propertySchedule = model;
            viewmodel.propertySchedule = new PropertySchedule();

            return View("AllProperties", viewmodel);
        }
        [HttpPost]
        public IActionResult AllProperties(PropertyScheduleCreateViewModel propertyScheduleViewModel)
        {
            if (ModelState.IsValid)
            {
                PropertySchedule property = _propertyScheduleRepositry.Add(propertyScheduleViewModel.propertySchedule);

                var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();

                PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
                viewmodel._propertySchedule = updatedProperties;
                viewmodel.propertySchedule = new PropertySchedule();

                return View("AllProperties", viewmodel);
                //return RedirectToAction("AllProperties", updatedProperties);
            }
            return View();
        }


        [HttpGet]
        public ViewResult EditProperty(int id)
        {
            PropertySchedule model= _propertyScheduleRepositry.GetPropertySchedule(id);
            ViewBag.PageTitle = "Edit Property";
           
            return View("EditProperty",model);
        }
        [HttpPost]
        public IActionResult EditProperty(PropertySchedule propertyScheduleChange)
        {
            if (ModelState.IsValid)
            {            
                _propertyScheduleRepositry.Update(propertyScheduleChange);

                var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();
                
                return RedirectToAction("AllProperties", updatedProperties);
            }

            return View("AllProperties");
        }
        public ViewResult DeleteProperty(int id)
        {
            _propertyScheduleRepositry.Delete(id);
            var RemainingProperties = _propertyScheduleRepositry.GetAllPropertySchedule();
            return View("AllProperties", RemainingProperties);
        }

        [HttpGet]
        public ViewResult PropertySchedule()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PropertySchedule(PropertySchedule propertySchedule)
        {
            if (ModelState.IsValid)
            {
                PropertySchedule property = _propertyScheduleRepositry.Add(propertySchedule);

                var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();
                return RedirectToAction("AllProperties", updatedProperties);
            }
            return View();
        }
    }
}
