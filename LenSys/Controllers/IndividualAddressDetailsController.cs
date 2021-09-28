using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
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
        public IndividualAddressDetailsController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AddressDetails");
        }
        [HttpGet]
        public ViewResult AddressDetails()
        {
            int IndividualId = AppAssetFinanceController.IndividualID;
            AddressDetails addressDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;

            return View(addressDetails);
            //return View();
        }
        [HttpPost]
        public IActionResult AddressDetails(AddressDetails addressDetails)
        {
            int id = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;

            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);

            appAssetFinanceIndividual.addressDetails = addressDetails;
            //return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            //if (ModelState.IsValid)
            //{
            //    //Employee newEmployee = _emplyeeRepositry.Add(employee);
            //    ////return View();
            //    //return RedirectToAction("details", new { id = newEmployee.Id });
            //    return View("AddressDetails");
            //}

            return View();
        }

    }
}
