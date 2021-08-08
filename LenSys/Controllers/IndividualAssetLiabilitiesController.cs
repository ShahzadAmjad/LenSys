using LenSys.Models.IndividualAssetLiabilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualAssetLiabilitiesController:Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AssetLiabilities");
        }
        [HttpGet]
        public ViewResult AssetLiabilities()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AssetLiabilities(AssetLiabilities assetLiabilities)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("AssetLiabilities");
            }

            return View();
        }
    }
}
