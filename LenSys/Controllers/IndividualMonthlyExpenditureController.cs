using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
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
        public IndividualMonthlyExpenditureController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            MonthlyExpenditure monthlyExpenditure;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId == 0)
            {
                monthlyExpenditure = new MonthlyExpenditure();
            }
            else
            {
                monthlyExpenditure = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }
             

            //return View(individualPersonalDetails);
           
            return View("MonthlyExpenditure", monthlyExpenditure);
        }
        [HttpGet]
        public ViewResult MonthlyExpenditure()
        {
            MonthlyExpenditure monthlyExpenditure;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId == 0)
            {
                monthlyExpenditure = new MonthlyExpenditure();
            }
            else
            {
                monthlyExpenditure = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).monthlyExpenditure;
            }
            return View(monthlyExpenditure);
        }
        [HttpPost]
        public IActionResult MonthlyExpenditure(MonthlyExpenditure monthlyExpenditure)
        {
            int id = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;

            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);

            appAssetFinanceIndividual.monthlyExpenditure = monthlyExpenditure;
            //return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            return View();

            //if (ModelState.IsValid)
            //{
            //    //Employee newEmployee = _emplyeeRepositry.Add(employee);
            //    ////return View();
            //    //return RedirectToAction("details", new { id = newEmployee.Id });
            //    return View("MonthlyExpenditure");
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
                return View("MonthlyExpenditure");
            }
        }
    }
}
