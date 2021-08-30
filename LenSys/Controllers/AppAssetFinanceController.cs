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
        private IAppAssetFinanceRepository _appAssetFinanceRepository;

        public AppAssetFinanceController(IAppAssetFinanceRepository appAssetFinanceRepository)
        {
            _appAssetFinanceRepository = appAssetFinanceRepository;
        }
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
                AppAssetFinance appAssetFinance1=_appAssetFinanceRepository.Add(appAssetFinance);

            }

             return View();
            //return JavaScript(alert(""));
        }
    }
}
