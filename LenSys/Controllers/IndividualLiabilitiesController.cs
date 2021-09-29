using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
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
        public IndividualLiabilitiesController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            int IndividualId = AppAssetFinanceController.IndividualID;
            Liabilities liabilities = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;

            return View("Liabilities",liabilities);
        }
        [HttpGet]
        public ViewResult Liabilities()
        {
            int IndividualId = AppAssetFinanceController.IndividualID;
            Liabilities liabilities = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).liabilities;

            return View(liabilities);
        }
        [HttpPost]
        public IActionResult Liabilities(Liabilities liabilities)
        {
            int id = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;

            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);

            appAssetFinanceIndividual.liabilities = liabilities;
            //if (ModelState.IsValid)
            //{
            //    //Employee newEmployee = _emplyeeRepositry.Add(employee);
            //    ////return View();
            //    //return RedirectToAction("details", new { id = newEmployee.Id });
            //    return View("Liabilities");
            //}

            return View();
        }
    }
}
