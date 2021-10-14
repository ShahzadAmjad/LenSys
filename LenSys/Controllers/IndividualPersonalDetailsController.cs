using LenSys.Models;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
using LenSys.Models.IndividualPersonalDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualPersonalDetailsController: Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;
        public IndividualPersonalDetailsController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository,
            IAppBusniessFinanceIndividualRepository appBusniessFinanceIndividualRepository,
            IAppDevelopmentFinanceIndividualRepository appDevelopmentFinanceIndividualRepository,
            IAppPropertyFinanceIndividualRepository appPropertyFinanceIndividualRepository)
        {
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
            _appBusniessFinanceIndividualRepository = appBusniessFinanceIndividualRepository;
            _appDevelopmentFinanceIndividualRepository = appDevelopmentFinanceIndividualRepository;
            _appPropertyFinanceIndividualRepository = appPropertyFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            PersonalDetails individualPersonalDetails;
            int IndividualId;
            
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                individualPersonalDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                individualPersonalDetails = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                individualPersonalDetails = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                individualPersonalDetails = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            }
            else
            {
                individualPersonalDetails = new PersonalDetails();
            }

            return View("PersonalDetails", individualPersonalDetails);
        }
        [HttpGet]
        public ViewResult PersonalDetails()
        {
            PersonalDetails individualPersonalDetails;
            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                individualPersonalDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                individualPersonalDetails = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                individualPersonalDetails = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                individualPersonalDetails = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            }
            else
            {
                individualPersonalDetails = new PersonalDetails();
            }
            //IndividualId = AppAssetFinanceController.IndividualID;
            //if(IndividualId==0)
            //{
            //    individualPersonalDetails = new PersonalDetails();
            //}
            //else
            //{
            //    individualPersonalDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            //}

            return View(individualPersonalDetails);
        }
        [HttpPost]
        public IActionResult PersonalDetails(PersonalDetails personalDetails)
        {
            int IndividualId;
            String editAppType = HomeController.EditAppType;
            
            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.personalDetails = personalDetails;
            }
            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.personalDetails = personalDetails;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.personalDetails = personalDetails;

            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.personalDetails = personalDetails;
            }

            //return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            return View(personalDetails);
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
                return View("PersonalDetails");
            }            
        }
    }
}
