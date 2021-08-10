using LenSys.Models.IndividualAssetLiabilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualAssetController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("Asset");
        }
        [HttpGet]
        public ViewResult Asset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Asset(Asset asset)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("Asset");
            }

            return View();
        }
    }
}
