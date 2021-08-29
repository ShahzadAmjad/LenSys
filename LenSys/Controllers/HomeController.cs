using LenSys.Models;
using LenSys.Models.Home;
using LenSys.Models.Home.AllApplications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class HomeController: Controller
    {
        private readonly IAllApplicationsRepository _allApplicationsRepository;

        public HomeController(IAllApplicationsRepository allApplicationsRepository)
        {
            this._allApplicationsRepository = allApplicationsRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("Lead");
        }
        [HttpGet]
        public ViewResult Lead()
        {
            return View();
        }
        public ViewResult Search()
        {
            return View();
        }
        public ViewResult DocumentList()
        {
            return View();
        }
        public ViewResult AllApplications()
        {
            var model = _allApplicationsRepository.GetAllApplications();
            return View(model);
        }
        public ViewResult DeleteApplication(int id)
        {
            _allApplicationsRepository.Delete(id);
            var RemainingApplications = _allApplicationsRepository.GetAllApplications();
            
            return View("AllApplications", RemainingApplications);
        }
        public ViewResult EditApplication(int id)
        {
            AllApplications application = _allApplicationsRepository.GetApplication(id);

            if(application.FinanceType=="Asset Finance")
            {
                return View("AppAssetFinance", "AppAssetFinance");
            }
            else if (application.FinanceType == "Busniess Finance")
            {
                return View("AppBusniessFinance", "AppBusniessFinance");
            }
            else if (application.FinanceType == "Development Finace")
            {
                return View("AppDevelopmentFinance", "AppDevelopmentFinance");
            }
            else if (application.FinanceType == "Property Finace")
            {
                return View("AppPropertyFinance", "AppPropertyFinance");
            }

            return View("AllApplications");
        }

        [HttpPost]
        public IActionResult Lead(Lead lead)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("Lead");
            }

            return View();
        }

    }
}
