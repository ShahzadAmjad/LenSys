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
            AddressDetails addressDetails;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId == 0)
            {
                addressDetails = new AddressDetails();
            }
            else
            {
                addressDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }
            return View("AddressDetails",addressDetails);
        }
        [HttpGet]
        public ViewResult AddressDetails()
        {
            AddressDetails addressDetails;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if(IndividualId==0)
            {
                addressDetails = new AddressDetails();
            }
            else
            {
                addressDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).addressDetails;
            }

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
