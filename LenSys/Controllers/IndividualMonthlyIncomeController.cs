using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.IndividualIncomeExpenditure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualMonthlyIncomeController : Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        public IndividualMonthlyIncomeController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            MonthlyIncome monthlyIncome;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId == 0)
            {
                monthlyIncome = new MonthlyIncome();
            }
            else
            {
                 monthlyIncome = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).monthlyIncome;
            }
            

            return View(monthlyIncome);
            //return View("MonthlyIncome", monthlyIncome);
        }
        [HttpGet]
        public ViewResult MonthlyIncome()
        {
            MonthlyIncome monthlyIncome;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId == 0)
            {
                monthlyIncome = new MonthlyIncome();
            }
            else
            {
                monthlyIncome = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).monthlyIncome;
            }
            return View(monthlyIncome);
            //return View();
        }
        [HttpPost]
        public IActionResult MonthlyIncome(MonthlyIncome income)
        {
            int id = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;

            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);

            appAssetFinanceIndividual.monthlyIncome = income;
            //return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            //if (ModelState.IsValid)
            //{
            //    //Employee newEmployee = _emplyeeRepositry.Add(employee);
            //    ////return View();
            //    //return RedirectToAction("details", new { id = newEmployee.Id });
            //    return View("MonthlyIncome");
            //}

            return View();
        }
    }
}
