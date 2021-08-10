using LenSys.Models.IndividualIncomeExpenditure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualMonthlyIncomeController : Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("MonthlyIncome");
        }
        [HttpGet]
        public ViewResult MonthlyIncome()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MonthlyIncome(MonthlyIncome incomeExpenditure)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("MonthlyIncome");
            }

            return View();
        }
    }
}
