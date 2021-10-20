using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
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
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;
        public IndividualPropertyScheduleController(IPropertyScheduleRepository propertyScheduleRepository,
            IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository,
            IAppBusniessFinanceIndividualRepository appBusniessFinanceIndividualRepository,
            IAppDevelopmentFinanceIndividualRepository appDevelopmentFinanceIndividualRepository,
            IAppPropertyFinanceIndividualRepository appPropertyFinanceIndividualRepository)
        {
            _propertyScheduleRepositry = propertyScheduleRepository;
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
            _appBusniessFinanceIndividualRepository = appBusniessFinanceIndividualRepository;
            _appDevelopmentFinanceIndividualRepository = appDevelopmentFinanceIndividualRepository;
            _appPropertyFinanceIndividualRepository = appPropertyFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            int IndividualId;
            var model= new List<PropertySchedule>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                IEnumerable<PropertySchedule> propertySchedulesList = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                 model= (List<PropertySchedule>)_propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                IEnumerable<PropertySchedule> propertySchedulesList = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                 model = (List<PropertySchedule>)_propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                IEnumerable<PropertySchedule> propertySchedulesList = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                 model = (List<PropertySchedule>)_propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                IEnumerable<PropertySchedule> propertySchedulesList = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                 model = (List<PropertySchedule>)_propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }
            else
            {
                 model = new List<PropertySchedule>();
            }

            PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
            viewmodel._propertySchedule =  model;
            viewmodel.propertySchedule = new PropertySchedule();
            return View("AllProperties", viewmodel);
        }
        [HttpGet]
        public ViewResult AllProperties()
        {
            //int IndividualId = AppAssetFinanceController.IndividualID;
            //if (IndividualId != 0)
            //{
            //    IEnumerable<PropertySchedule> propertySchedulesList = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
            //    _propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            //}
            //var model = _propertyScheduleRepositry.GetAllPropertySchedule();
            int IndividualId;
            var model = new List<PropertySchedule>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                IEnumerable<PropertySchedule> propertySchedulesList = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                model = (List<PropertySchedule>)_propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                IEnumerable<PropertySchedule> propertySchedulesList = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                model = (List<PropertySchedule>)_propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                IEnumerable<PropertySchedule> propertySchedulesList = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                model = (List<PropertySchedule>)_propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                IEnumerable<PropertySchedule> propertySchedulesList = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).propertySchedule;
                model = (List<PropertySchedule>)_propertyScheduleRepositry.SetPropertyScheduleList(propertySchedulesList);
            }
            else
            {
                model = new List<PropertySchedule>();
            }
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
            PropertySchedule property = _propertyScheduleRepositry.Add(propertySchedule);
            var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();



            //int IndividualId = AppAssetFinanceController.IndividualID;
            //AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
            //appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }
            
            PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
            viewmodel._propertySchedule = updatedProperties;
            viewmodel.propertySchedule = new PropertySchedule();

            return View("AllProperties", viewmodel);            
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
            //if (ModelState.IsValid)
            //{            
                _propertyScheduleRepositry.Update(propertyScheduleChange);
                var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();
                //int IndividualId = AppAssetFinanceController.IndividualID;
                //AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                //appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
                int IndividualId;
                String editAppType = HomeController.EditAppType;

                if (editAppType == "Asset finance")
                {
                    IndividualId = AppAssetFinanceController.IndividualID;
                    AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                    appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
                }

                else if (editAppType == "Business finance")
                {
                    IndividualId = AppBusniessFinanceController.IndividualID;
                    AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                    appBusniessFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
                }
                else if (editAppType == "Development finance")
                {
                    IndividualId = AppDevelopmentFinanceController.IndividualID;
                    AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                    appDevelopmentFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
                }
                else if (editAppType == "Property finance")
                {
                    IndividualId = AppPropertyFinanceController.IndividualID;
                    AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                    appPropertyFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
                }

                PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
                viewmodel._propertySchedule = updatedProperties;
                viewmodel.propertySchedule = new PropertySchedule();
                return RedirectToAction("AllProperties", viewmodel);
            //}

            //return View("AllProperties");
        }
        public ViewResult DeleteProperty(int id)
        {
            _propertyScheduleRepositry.Delete(id);
            var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();
            //int IndividualId = AppAssetFinanceController.IndividualID;
            //AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
            //appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }
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
            //if (ModelState.IsValid)
            //{
                PropertySchedule property = _propertyScheduleRepositry.Add(propertySchedule);
                var updatedProperties = _propertyScheduleRepositry.GetAllPropertySchedule();
            //int IndividualId = AppAssetFinanceController.IndividualID;
            //AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
            //appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }
            PropertyScheduleCreateViewModel viewmodel = new PropertyScheduleCreateViewModel();
            viewmodel._propertySchedule = updatedProperties;
            viewmodel.propertySchedule = new PropertySchedule();

            return RedirectToAction("AllProperties", viewmodel);
            //}
            //return View();
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
