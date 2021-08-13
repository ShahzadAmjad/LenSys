using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessUploadDocumentsController:Controller
    {
        public ViewResult Index()
        {

            return View("BusniessUploadDocuments");

        }
        public ViewResult BusniessUploadDocuments()
        {

            return View();

        }
    }
}
