using LenSys.Models.IndividualCreditHistory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualCreditHistoryController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("CreditHistory");
        }
        [HttpGet]
        public ViewResult CreditHistory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreditHistory(CreditHistory creditHistory)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("CreditHistory");
            }

            return View();
        }
    }
}
