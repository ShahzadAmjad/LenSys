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
            int IndividualId = AppAssetFinanceController.IndividualID;
            PersonalDetails individualPersonalDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;

            //return View(individualPersonalDetails);
            return View("PersonalDetails", individualPersonalDetails);
        }
        [HttpGet]
        public ViewResult PersonalDetails()
        {
            PersonalDetails individualPersonalDetails;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if(IndividualId==0)
            {
                individualPersonalDetails = new PersonalDetails();
            }
            else
            {
                individualPersonalDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).personalDetails;
            }

            return View(individualPersonalDetails);
        }
        [HttpPost]
        public IActionResult PersonalDetails(PersonalDetails personalDetails)
        {
            int id = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;

            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);

            appAssetFinanceIndividual.personalDetails = personalDetails;
            //return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            return View();
        }


    }
}
