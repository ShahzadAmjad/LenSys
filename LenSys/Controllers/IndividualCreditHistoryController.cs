using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
using LenSys.Models.IndividualCreditHistory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualCreditHistoryController:Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;
        public IndividualCreditHistoryController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository,
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
            CreditHistory creditHistory;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                creditHistory = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                creditHistory = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                creditHistory = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                creditHistory = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }
            else
            {
                creditHistory = new CreditHistory();
            }

            return View("CreditHistory", creditHistory);
        }
        [HttpGet]
        public ViewResult CreditHistory()
        {
            CreditHistory creditHistory;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                creditHistory = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                creditHistory = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                creditHistory = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                creditHistory = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }
            else
            {
                creditHistory = new CreditHistory();
            }
            return View(creditHistory);
        }
        [HttpPost]
        public IActionResult CreditHistory(CreditHistory creditHistory)
        {
            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.creditHistory = creditHistory;
            }
            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.creditHistory = creditHistory;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.creditHistory = creditHistory;

            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.creditHistory = creditHistory;
            }     
            return View(creditHistory);
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
                return View("CreditHistory");
            }
        }
    }
}
