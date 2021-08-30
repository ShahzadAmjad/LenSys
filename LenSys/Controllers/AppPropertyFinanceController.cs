using LenSys.Models.AppPropertyFinance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class AppPropertyFinanceController : Controller
    {
        private IAppPropertyFinanceSecurityDetailsRepository _appPropertyFinanceSecurityDetails;
        //public List<AppPropertyFinanceSecurityDetails> _SecurityDetails;

        public AppPropertyFinanceController(IAppPropertyFinanceSecurityDetailsRepository appPropertyFinanceSecurityDetailsRepository)
        {
            _appPropertyFinanceSecurityDetails = appPropertyFinanceSecurityDetailsRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AppPropertyFinance");
        }

        [HttpGet]
        public IActionResult AddSecurityDetail()
        {

            AppPropertyFinanceSecurityDetails securityDetails = new AppPropertyFinanceSecurityDetails();
            return PartialView("_AddSecutityDetailPropertyPartialView", securityDetails);

            //return View("EditSecurityDetail", model);
        }
        [HttpPost]
        public IActionResult AddSecurityDetail(AppPropertyFinanceSecurityDetails securityDetails)
        {
            _appPropertyFinanceSecurityDetails.Add(securityDetails);
            //AppBusniessFinanceSecurityDetails securityDetails = new AppBusniessFinanceSecurityDetails();
            //return PartialView("_AddSecutityDetailBusniessPartialView", securityDetails);

            ViewData["SecurityDetailsList"] = _appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            return View("AppPropertyFinance");
        }


        [HttpGet]
        public IActionResult EditSecurityDetail(int id)
        {


            AppPropertyFinanceSecurityDetails securityDetails = _appPropertyFinanceSecurityDetails.GetAppPropertysFinanceSecurityDetails(id);
            //return View("EditSecurityDetail",model);

            return PartialView("_EditSecurityDetailPropertyPartialView", securityDetails);

        }

        [HttpGet]
        public ViewResult AppPropertyFinance()
        {
            
            ViewData["SecurityDetailsList"] = _appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();

            return View("AppPropertyFinance");

            //return View();
        }
        [HttpPost]
        public IActionResult AppPropertyFinance(AppPropertyFinance appBusniessFinance)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("Index", "Home");
            }

            return View();
        }
    }
}
