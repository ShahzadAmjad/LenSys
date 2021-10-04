using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.IndividualEmploymentDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualEmploymentDetailsController: Controller
    {
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        public IndividualEmploymentDetailsController(IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            EmploymentDetails employmentDetails;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId == 0)
            {
                employmentDetails = new EmploymentDetails();
            }
            else
            {
                employmentDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }

            return View("EmploymentDetails", employmentDetails);
        }
        [HttpGet]
        public ViewResult EmploymentDetails()
        {
            EmploymentDetails employmentDetails;
            int IndividualId = AppAssetFinanceController.IndividualID;
            if (IndividualId == 0)
            {
                employmentDetails = new EmploymentDetails();
            }
            else
            {
                employmentDetails = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).employmentDetails;
            }
            return View(employmentDetails);
            //return View();
        }
        [HttpPost]
        public IActionResult EmploymentDetails(EmploymentDetails employmentDetails)
        {
            int id = AppAssetFinanceController.appID;
            int IndividualId = AppAssetFinanceController.IndividualID;

            AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);

            appAssetFinanceIndividual.employmentDetails = employmentDetails;
            //return RedirectToAction("AppAssetFinance", "AppAssetFinance", new { id = id });
            //if (ModelState.IsValid)
            //{
            //    //Employee newEmployee = _emplyeeRepositry.Add(employee);
            //    ////return View();
            //    //return RedirectToAction("details", new { id = newEmployee.Id });
            //    return View("EmploymentDetails");
            //}

            return View();
        }
    }
}
