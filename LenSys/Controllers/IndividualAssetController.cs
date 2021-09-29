using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.IndividualAsset;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualAssetController:Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        public IndividualAssetController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            Asset asset;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if(IndividualId==0)
            {
                asset = new Asset();
            }
            else
            {
                asset = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).asset;
            }


            return View("Asset",asset);
        }
        [HttpGet]
        public ViewResult Asset()
        {
            int IndividualId = AppAssetFinanceController.IndividualID;
            Asset asset = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).asset;

            return View(asset);
        }
        [HttpPost]
        public IActionResult Asset(Asset asset)
        {
            int id = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;

            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);

            appAssetFinanceIndividual.asset = asset;
            //return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            return View();


            //if (ModelState.IsValid)
            //{
            //    //Employee newEmployee = _emplyeeRepositry.Add(employee);
            //    ////return View();
            //    //return RedirectToAction("details", new { id = newEmployee.Id });
            //    return View("Asset");
            //}

            //return View();
        }
    }
}
