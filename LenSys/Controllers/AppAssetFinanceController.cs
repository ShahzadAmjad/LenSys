using LenSys.Models.AppAssetFinance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class AppAssetFinanceController : Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AppAssetFinance");
        }
        [HttpGet]
        public ViewResult AppAssetFinance()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AppAssetFinance(AppAssetFinance appAssetFinance)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("Index","Home");
            }

            return View();
        }
    }
}
