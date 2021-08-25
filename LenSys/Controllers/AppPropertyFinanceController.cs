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
        public ViewResult EditSecurityDetail(int id)
        {


            AppPropertyFinanceSecurityDetails model = _appPropertyFinanceSecurityDetails.GetAppPropertysFinanceSecurityDetails(id);
            //ViewBag.PageTitle = "Edit Key Principal";

            return View("EditSecurityDetail",model);
        }
        [HttpGet]
        public ViewResult AppPropertyFinance()
        {
            //_SecurityDetails = new List<AppPropertyFinanceSecurityDetails>()
            //{
            //    new AppPropertyFinanceSecurityDetails
            //    {
            //            SecurityDetailsId=1,
                       
            //            SecurityType= "Residential ",
            //            PropertyType="1 Bed Appartment",
                         
            //            AlreadyOwned="YES",
            //            NameOfPropertyOwner = "John",
            //            Tenure= 2,
            //            YearsRemainingOnLeaseIfLeaseHold= 1,
            //            PropertyValue= 5454,
            //            OriginalPurchasePrice= 6000,
            //            UseOfFunds="Security Money",
            //            Rent=50,
            //            HMO_MUFB="abc",
            //            AddressForPropertyOfSecurity="Russia",
            //            SecondLineAddress= "Cremlin",
            //            City= "Moscow",
            //            PostCode= 85000

            //    }
            //};

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
