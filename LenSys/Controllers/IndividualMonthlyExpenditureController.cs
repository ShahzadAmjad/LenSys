using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
using LenSys.Models.IndividualMonthlyExpenditure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualMonthlyExpenditureController:Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;
        public IndividualMonthlyExpenditureController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository,
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
            MonthlyExpenditure monthlyExpenditure;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                monthlyExpenditure = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                monthlyExpenditure = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                monthlyExpenditure = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                monthlyExpenditure = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }
            else
            {
                monthlyExpenditure = new MonthlyExpenditure();
            }
            return View("MonthlyExpenditure", monthlyExpenditure);
        }
        [HttpGet]
        public ViewResult MonthlyExpenditure()
        {
            MonthlyExpenditure monthlyExpenditure;
            int IndividualId;

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                monthlyExpenditure = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                monthlyExpenditure = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                monthlyExpenditure = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                monthlyExpenditure = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }
            else
            {
                monthlyExpenditure = new MonthlyExpenditure();
            }
            return View(monthlyExpenditure);
        }
        [HttpPost]
        public IActionResult MonthlyExpenditure(MonthlyExpenditure monthlyExpenditure)
        {
            //int IndividualId = AppAssetFinanceController.IndividualID;
            //AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
            //appAssetFinanceIndividual.monthlyExpenditure = monthlyExpenditure;
            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.monthlyExpenditure = monthlyExpenditure;
            }
            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.monthlyExpenditure = monthlyExpenditure;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.monthlyExpenditure = monthlyExpenditure;

            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.monthlyExpenditure = monthlyExpenditure;
            }
            return View(monthlyExpenditure);
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
                return View("MonthlyExpenditure");
            }
        }
    }
}
