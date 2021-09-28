using LenSys.Models;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.IndividualPersonalDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualPersonalDetailsController: Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        public IndividualPersonalDetailsController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("PersonalDetails");
        }
        [HttpGet]
        public ViewResult PersonalDetails()
        {
            int IndividualId = AppAssetFinanceController.IndividualID;
            PersonalDetails individualPersonalDetails=_appAssetFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            
            return View(individualPersonalDetails);
        }
        [HttpPost]
        public IActionResult PersonalDetails(PersonalDetails personalDetails)
        {
            int id = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;

            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);

            
            //if (ModelState.IsValid)
            {
                appAssetFinanceIndividual.personalDetails = personalDetails;
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            }

            //return View();
        }


    }
}
