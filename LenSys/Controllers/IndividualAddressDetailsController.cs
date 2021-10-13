using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
using LenSys.Models.IndividualAddressDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualAddressDetailsController: Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;
        public IndividualAddressDetailsController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository,
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
            AddressDetails addressDetails;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                addressDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                addressDetails = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                addressDetails = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                addressDetails = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }
            else
            {
                addressDetails = new AddressDetails();
            }
            
            return View("AddressDetails",addressDetails);
        }
        [HttpGet]
        public ViewResult AddressDetails()
        {
            AddressDetails addressDetails;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                addressDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                addressDetails = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                addressDetails = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                addressDetails = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }
            else
            {
                addressDetails = new AddressDetails();
            }

            return View("AddressDetails", addressDetails);
        }
        [HttpPost]
        public IActionResult AddressDetails(AddressDetails addressDetails)
        {

            //int IndividualId = AppAssetFinanceController.IndividualID;
            //AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
            //appAssetFinanceIndividual.addressDetails = addressDetails;

            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                //id = AppAssetFinanceController.appID;
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.addressDetails = addressDetails;
            }
            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.addressDetails = addressDetails;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.addressDetails = addressDetails;

            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.addressDetails = addressDetails;
            }
            return View(addressDetails);
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
                return View("AddressDetails");
            }
        }
    }
}
