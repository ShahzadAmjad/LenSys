using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
using LenSys.Models.IndividualEmploymentDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualEmploymentDetailsController: Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;
        public IndividualEmploymentDetailsController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository,
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
            EmploymentDetails employmentDetails;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                employmentDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                employmentDetails = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                employmentDetails = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                employmentDetails = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }
            else
            {
                employmentDetails = new EmploymentDetails();
            }
            //int IndividualId = AppAssetFinanceController.IndividualID;
            //if (IndividualId == 0)
            //{
            //    employmentDetails = new EmploymentDetails();
            //}
            //else
            //{
            //    employmentDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            //}

            return View("EmploymentDetails", employmentDetails);
        }
        [HttpGet]
        public ViewResult EmploymentDetails()
        {
            EmploymentDetails employmentDetails;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                employmentDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                employmentDetails = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                employmentDetails = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                employmentDetails = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }
            else
            {
                employmentDetails = new EmploymentDetails();
            }
            return View(employmentDetails);
        }
        [HttpPost]
        public IActionResult EmploymentDetails(EmploymentDetails employmentDetails)
        {
            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.employmentDetails = employmentDetails;
            }
            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.employmentDetails = employmentDetails;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.employmentDetails = employmentDetails;

            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.employmentDetails = employmentDetails;
            }
            return View(employmentDetails);
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
                return View("EmploymentDetails");
            }
        }
    }
}
