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
        //[HttpGet]
        public ViewResult AppPropertyFinance()
        {
            return View();
        }
    }
}
