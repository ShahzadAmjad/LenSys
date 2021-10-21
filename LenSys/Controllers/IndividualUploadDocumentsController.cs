using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
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
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;
        private IAppBusniessFinanceIndividualRepository _appBusniessFinanceIndividualRepository;
        private IAppDevelopmentFinanceIndividualRepository _appDevelopmentFinanceIndividualRepository;
        private IAppPropertyFinanceIndividualRepository _appPropertyFinanceIndividualRepository;

        private readonly IHostingEnvironment hostingEnvironment;
        //private readonly IWebHost webHosting;

        public IndividualUploadDocumentsController(IindividualDocumentsRepository iindividualDocumentsRepository,
            IHostingEnvironment hostingEnvironment,
            IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository,
            IAppBusniessFinanceIndividualRepository appBusniessFinanceIndividualRepository,
            IAppDevelopmentFinanceIndividualRepository appDevelopmentFinanceIndividualRepository,
            IAppPropertyFinanceIndividualRepository appPropertyFinanceIndividualRepository)
        {
            _iindividualDocumentsRepository = iindividualDocumentsRepository;
            this.hostingEnvironment = hostingEnvironment;
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
            _appBusniessFinanceIndividualRepository = appBusniessFinanceIndividualRepository;
            _appDevelopmentFinanceIndividualRepository = appDevelopmentFinanceIndividualRepository;
            _appPropertyFinanceIndividualRepository = appPropertyFinanceIndividualRepository;

            //this.webHosting = webHosting; 
        }
        public ViewResult Index()
        {
            int IndividualId;
            var model = new List<IndividualDocuments>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                IEnumerable<IndividualDocuments> individualDocumentsList = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).individualDocuments;
                model = (List<IndividualDocuments>)_iindividualDocumentsRepository.SetIndividualDocumentsList(individualDocumentsList);
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                IEnumerable<IndividualDocuments> individualDocumentsList = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).individualDocuments;
                model = (List<IndividualDocuments>)_iindividualDocumentsRepository.SetIndividualDocumentsList(individualDocumentsList);
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                IEnumerable<IndividualDocuments> individualDocumentsList = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).individualDocuments;
                model = (List<IndividualDocuments>)_iindividualDocumentsRepository.SetIndividualDocumentsList(individualDocumentsList);
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                IEnumerable<IndividualDocuments> individualDocumentsList = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).individualDocuments;
                model = (List<IndividualDocuments>)_iindividualDocumentsRepository.SetIndividualDocumentsList(individualDocumentsList);
            }
            else
            {
                model = new List<IndividualDocuments>();
            }

            
            return View("AllIndividualDocuments", model);
            //return View("IndividualUploadDocuments");            
        }
        [HttpGet]
        public ViewResult AllIndividualDocuments()
        {
            int IndividualId;
            var model = new List<IndividualDocuments>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                IEnumerable<IndividualDocuments> individualDocumentsList = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId).individualDocuments;
                model = (List<IndividualDocuments>)_iindividualDocumentsRepository.SetIndividualDocumentsList(individualDocumentsList);
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                IEnumerable<IndividualDocuments> individualDocumentsList = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId).individualDocuments;
                model = (List<IndividualDocuments>)_iindividualDocumentsRepository.SetIndividualDocumentsList(individualDocumentsList);
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                IEnumerable<IndividualDocuments> individualDocumentsList = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId).individualDocuments;
                model = (List<IndividualDocuments>)_iindividualDocumentsRepository.SetIndividualDocumentsList(individualDocumentsList);
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                IEnumerable<IndividualDocuments> individualDocumentsList = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId).individualDocuments;
                model = (List<IndividualDocuments>)_iindividualDocumentsRepository.SetIndividualDocumentsList(individualDocumentsList);
            }
            else
            {
                model = new List<IndividualDocuments>();
            }


            return View("AllIndividualDocuments", model);
        }
        public ViewResult DeleteIndividualDocuments(int id)
        {
            _iindividualDocumentsRepository.Delete(id);
            var updatedIndividualDocuments = _iindividualDocumentsRepository.GetAllIndividualDocuments();
            
            int IndividualId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                IndividualId = AppAssetFinanceController.IndividualID;
                AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                appAssetFinanceIndividual.individualDocuments = (List<IndividualDocuments>)updatedIndividualDocuments;
            }

            else if (editAppType == "Business finance")
            {
                IndividualId = AppBusniessFinanceController.IndividualID;
                AppBusniessFinanceIndividual appBusniessFinanceIndividual = _appBusniessFinanceIndividualRepository.GetIndividual(IndividualId);
                appBusniessFinanceIndividual.individualDocuments = (List<IndividualDocuments>)updatedIndividualDocuments;
            }
            else if (editAppType == "Development finance")
            {
                IndividualId = AppDevelopmentFinanceController.IndividualID;
                AppDevelopmentFinanceIndividual appDevelopmentFinanceIndividual = _appDevelopmentFinanceIndividualRepository.GetIndividual(IndividualId);
                appDevelopmentFinanceIndividual.individualDocuments = (List<IndividualDocuments>)updatedIndividualDocuments;
            }
            else if (editAppType == "Property finance")
            {
                IndividualId = AppPropertyFinanceController.IndividualID;
                AppPropertyFinanceIndividual appPropertyFinanceIndividual = _appPropertyFinanceIndividualRepository.GetIndividual(IndividualId);
                appPropertyFinanceIndividual.individualDocuments = (List<IndividualDocuments>)updatedIndividualDocuments;
            }

            return View("AllIndividualDocuments", updatedIndividualDocuments);
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
                string filePath = null;
                String DocGuid = null;
                if (model.Document != null)
                {
                    string UploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "IndividualDocuments");
                    DocGuid = Guid.NewGuid().ToString();
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Document.FileName;
                    filePath = Path.Combine(UploadsFolder, uniqueFileName);
                    model.Document.CopyTo(new FileStream(filePath, FileMode.Create));               
                }

                int IndividualId=0;
                int ApplicationId = 0;
                String editAppType = HomeController.EditAppType;
                if (editAppType == "Asset finance")
                {
                    ApplicationId = AppAssetFinanceController.appID;
                    IndividualId = AppAssetFinanceController.IndividualID;                 
                }
                else if (editAppType == "Business finance")
                {
                    IndividualId = AppBusniessFinanceController.IndividualID;
                    ApplicationId = AppBusniessFinanceController.appID;
                }
                else if (editAppType == "Development finance")
                {
                    IndividualId = AppDevelopmentFinanceController.IndividualID;
                    ApplicationId = AppDevelopmentFinanceController.appID;
                }
                else if (editAppType == "Property finance")
                {
                    IndividualId = AppPropertyFinanceController.IndividualID;
                    ApplicationId = AppPropertyFinanceController.appID;
                }

                //To save data to database
                IndividualDocuments individualDocuments = new IndividualDocuments
                {
                    AppId = ApplicationId,
                    IndividualId = IndividualId,
                    DocumentName = model.DocumentName,
                    DocumentPath = filePath,
                    DocumentGuid = DocGuid
                };
                IndividualDocuments individualDocuments1 = _iindividualDocumentsRepository.Add(individualDocuments);
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
