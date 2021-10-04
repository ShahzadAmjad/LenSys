using LenSys.Models.BusniessUploadDocument;
using LenSys.ViewModels.BusniessUploadDocuments;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessUploadDocumentsController:Controller
    {
        private IBusniessDocumentsRepository _busniessDocumentsRepository;

        private IHostingEnvironment hostingEnvironment;
        public BusniessUploadDocumentsController(IBusniessDocumentsRepository busniessDocumentsRepository, IHostingEnvironment hostingEnvironment)
        {
            _busniessDocumentsRepository = busniessDocumentsRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {

            return View("BusniessUploadDocuments");

        }
        [HttpGet]
        public ViewResult BusniessUploadDocuments()
        {

            return View();

        }
        [HttpPost]
        public IActionResult BusniessUploadDocuments(BusniessDocumentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Document!=null)
                {
                    string UploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "BusniessDocument");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Document.FileName;
                    string filePath = Path.Combine(UploadsFolder, uniqueFileName);
                    model.Document.CopyTo(new FileStream(filePath,FileMode.Create));
                }

                BusniessDocuments busniessDocuments = new BusniessDocuments
                {
                    DocumentName = model.DocumentName,
                    DocumentPath = uniqueFileName
                };

                BusniessDocuments busniessDocuments1 = _busniessDocumentsRepository.UploadDocument(busniessDocuments);

                return View();
            }

            return View();
        }


    }
}
