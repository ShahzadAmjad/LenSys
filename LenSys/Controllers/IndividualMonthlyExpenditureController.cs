using LenSys.Models.IndividualMonthlyExpenditure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualMonthlyExpenditureController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("MonthlyExpenditure");
        }
        [HttpGet]
        public ViewResult MonthlyExpenditure()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MonthlyExpenditure(MonthlyExpenditure monthlyExpenditure)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("MonthlyExpenditure");
            }

            return View();
        }
    }
}
