using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
using LenSys.Models.IndividualLiabilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualLiabilitiesController:Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;
        public IndividualLiabilitiesController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository,
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
            Liabilities liabilities;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                liabilities = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                liabilities = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                liabilities = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                liabilities = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;
            }
            else
            {
                liabilities = new Liabilities();
            }
            return View("Liabilities",liabilities);
        }
        [HttpGet]
        public ViewResult Liabilities()
        {
            Liabilities liabilities;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                liabilities = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                liabilities = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                liabilities = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                liabilities = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;
            }
            else
            {
                liabilities = new Liabilities();
            }         
            return View(liabilities);
        }
        [HttpPost]
        public IActionResult Liabilities(Liabilities liabilities)
        {
            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.liabilities = liabilities;
            }
            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.liabilities = liabilities;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.liabilities = liabilities;

            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.liabilities = liabilities;
            }
            //int IndividualId = AppAssetFinanceController.IndividualID;
            //AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
            //appAssetFinanceIndividual.liabilities = liabilities;

            return View(liabilities);
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
                return View("Liabilities");
            }
        }
    }
}
