using LenSys.Models.IndividualUploadDocuments;
using LenSys.ViewModels.IndividualUploadDocuments;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualUploadDocumentsController:Controller
    {
        private IindividualDocumentsRepository _iindividualDocumentsRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        //private readonly IWebHost webHosting;

        public IndividualUploadDocumentsController(IindividualDocumentsRepository iindividualDocumentsRepository, IHostingEnvironment hostingEnvironment)
        {
            _iindividualDocumentsRepository = iindividualDocumentsRepository;
            this.hostingEnvironment = hostingEnvironment;
            //this.webHosting = webHosting; 
        }
        public ViewResult Index()
        {
           
            return View("IndividualUploadDocuments");
            
        }
        [HttpGet]
        public ViewResult IndividualUploadDocuments()
        {

            return View();

        }

        [HttpPost]
        public IActionResult IndividualUploadDocuments(IndividualDocumentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Document != null)
                {
                    string UploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "IndividualDocuments");                    
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Document.FileName;
                    string filePath = Path.Combine(UploadsFolder, uniqueFileName);
                    model.Document.CopyTo(new FileStream(filePath, FileMode.Create));

                    
                }

                //To save data to database
                IndividualDocuments individualDocuments = new IndividualDocuments
                {
                    DocumentName = model.DocumentName,
                    DocumentPath = uniqueFileName
                };
                IndividualDocuments individualDocuments1 = _iindividualDocumentsRepository.UploadDocument(individualDocuments);

                //var updatedServiceability = _iindividualDocumentsRepository.GetAllServiceability();
                //return RedirectToAction("AllServiceability", updatedServiceability);
                //return RedirectToAction("Index", "Home");
                return View();
            }

            return View();
        }

        public IActionResult ReturnToParentApp()
        {
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                return RedirectToAction("AppAssetFinance", "AppAssetFinance");
            }

            else if (editAppType == "Business finance")
            {
                return RedirectToAction("AppBusniessFinance", "AppBusniessFinance");
            }
            else if (editAppType == "Development finance")
            {
                return RedirectToAction("AppDevelopmentFinance", "AppDevelopmentFinance");
            }
            else if (editAppType == "Property finance")
            {
                return RedirectToAction("AppPropertyFinance", "AppPropertyFinance");
            }
            else
            {
                return View("IndividualUploadDocuments");
            }
        }
    }
}
