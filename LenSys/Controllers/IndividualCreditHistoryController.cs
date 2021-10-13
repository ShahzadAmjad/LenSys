using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
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
        public IndividualCreditHistoryController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }

        public ViewResult Index()
        {
            CreditHistory creditHistory;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if(IndividualId==0)
            {
                creditHistory = new CreditHistory();
            }
            else
            {
                creditHistory = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }
            
            return View("CreditHistory", creditHistory);
        }
        [HttpGet]
        public ViewResult CreditHistory()
        {
            CreditHistory creditHistory;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId == 0)
            {
                creditHistory = new CreditHistory();
            }
            else
            {
                creditHistory = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).creditHistory;
            }
            return View(creditHistory);
        }
        [HttpPost]
        public IActionResult CreditHistory(CreditHistory creditHistory)
        {
            int id = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;

            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);

            appAssetFinanceIndividual.creditHistory = creditHistory;
            //return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            
            //if (ModelState.IsValid)
            //{
            //    //Employee newEmployee = _emplyeeRepositry.Add(employee);
            //    ////return View();
            //    //return RedirectToAction("details", new { id = newEmployee.Id });
            //    return View("CreditHistory");
            //}

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
                return View("CreditHistory");
            }
        }
    }
}
