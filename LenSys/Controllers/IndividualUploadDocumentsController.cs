using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualUploadDocumentsController:Controller
    {
        public ViewResult Index()
        {
           
            return View("IndividualUploadDocuments");
            
        }

        public ViewResult IndividualUploadDocuments()
        {

            return View();

        }

    }
}
