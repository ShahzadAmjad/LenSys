using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class AppDevelopmentFinanceController: Controller
    {
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AppDevelopmentFinance");
        }
        //[HttpGet]
        public ViewResult AppDevelopmentFinance()
        {
            return View();
        }
    }
}
