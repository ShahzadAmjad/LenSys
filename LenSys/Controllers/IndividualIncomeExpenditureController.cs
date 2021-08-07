using LenSys.Models.IndividualIncomeExpenditure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualIncomeExpenditureController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("IncomeExpenditure");
        }
        [HttpGet]
        public ViewResult IncomeExpenditure()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IncomeExpenditure(IncomeExpenditure incomeExpenditure)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("IncomeExpenditure");
            }

            return View();
        }
    }
}
