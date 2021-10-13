using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
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
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        public IndividualPropertyScheduleController(IPropertyScheduleRepository propertyScheduleRepository, IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _propertyScheduleRepositry = propertyScheduleRepository;
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId != 0)
            {
                IEnumerable<PropertySchedule> propertySchedulesList = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                _propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }

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
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId != 0)
            {
                IEnumerable<PropertySchedule> propertySchedulesList = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                _propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }

            var model = _propertyScheduleRepositry.GetAllPropertySchedule();
            //var tuple= new Tuple<ModelBinderAttribute,>
            PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
            viewmodel._propertySchedule = model;
            viewmodel.propertySchedule = new PropertySchedule();

            return View("AllProperties", viewmodel);
        }
        //Not called
        //[HttpPost]
        //public IActionResult AllProperties(PropertyScheduleCreateViewModel propertyScheduleViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        PropertySchedule property = _propertyScheduleRepositry.Add(propertyScheduleViewModel.propertySchedule);

        //        var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();

        //        PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
        //        viewmodel._propertySchedule = updatedProperties;
        //        viewmodel.propertySchedule = new PropertySchedule();

        //        //copy from personaldetail controler
        //        int id = AppAssetFinanceController.appID;
        //        int IndividualId = AppAssetFinanceController.IndividualID;
        //        AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
        //        appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;

        //        return View("AllProperties", viewmodel);
        //        //return RedirectToAction("AllProperties", updatedProperties);
        //    }
        //    return View();
        //}
        [HttpGet]
        public IActionResult AddPropertySchedule()
        {
            PropertySchedule propertySchedule = new PropertySchedule();
            return PartialView("_AddPropertySchedulePartialView", propertySchedule);           
        }
        [HttpPost]
        public IActionResult AddPropertySchedule(PropertySchedule propertySchedule)
        {
           // if (ModelState.IsValid)
            {
                PropertySchedule property = _propertyScheduleRepositry.Add(propertySchedule);
                var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();

                int IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;

                PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
                viewmodel._propertySchedule = updatedProperties;
                viewmodel.propertySchedule = new PropertySchedule();

                return View("AllProperties", viewmodel);
            }

            //return View();
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

                int id = AppAssetFinanceController.appID;
                int IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;

                return RedirectToAction("AllProperties", updatedProperties);
            }

            return View("AllProperties");
        }
        public ViewResult DeleteProperty(int id)
        {
            _propertyScheduleRepositry.Delete(id);
            var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();

            int AppId = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;
            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
            appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;

            PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
            viewmodel._propertySchedule = updatedProperties;
            viewmodel.propertySchedule = new PropertySchedule();

            return View("AllProperties", viewmodel);
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

                int id = AppAssetFinanceController.appID;
                int IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;


                return RedirectToAction("AllProperties", updatedProperties);
            }
            return View();
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
                return View("AllProperties");
            }
        }
    }
}
