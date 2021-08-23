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
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AppPropertyFinance");
        }
        [HttpGet]
        public ViewResult AppPropertyFinance()
        {
            return View();
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
