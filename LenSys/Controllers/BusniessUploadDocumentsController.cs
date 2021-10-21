using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess;
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
        private IAppAssetFinanceBusniessRepository _appAssetFinanceBusniessRepository;
        private IAppBusniessFinanceBusniessRepository _appBusniessFinanceBusniessRepository;
        private IAppDevelopmentFinanceBusniessRepository _appDevelopmentFinanceBusniessRepository;
        private IAppPropertyFinanceBusniessRepository _appPropertyFinanceBusniessRepository;

        private IHostingEnvironment hostingEnvironment;
        public BusniessUploadDocumentsController(IBusniessDocumentsRepository busniessDocumentsRepository,
            IHostingEnvironment hostingEnvironment,
            IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository,
            IAppBusniessFinanceBusniessRepository appBusniessFinanceBusniessRepository,
            IAppDevelopmentFinanceBusniessRepository appDevelopmentFinanceBusniessRepository,
            IAppPropertyFinanceBusniessRepository appPropertyFinanceBusniessRepository)
        {
            _busniessDocumentsRepository = busniessDocumentsRepository;
            this.hostingEnvironment = hostingEnvironment;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
            _appBusniessFinanceBusniessRepository = appBusniessFinanceBusniessRepository;
            _appDevelopmentFinanceBusniessRepository = appDevelopmentFinanceBusniessRepository;
            _appPropertyFinanceBusniessRepository = appPropertyFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            int BusniessId;
            var model = new List<BusniessDocuments>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                IEnumerable<BusniessDocuments> busniessDocuments = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessDocuments;
                model = (List<BusniessDocuments>)_busniessDocumentsRepository.SetBusniessDocumentsList(busniessDocuments);
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                IEnumerable<BusniessDocuments> busniessDocuments = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).busniessDocuments;
                model = (List<BusniessDocuments>)_busniessDocumentsRepository.SetBusniessDocumentsList(busniessDocuments);
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                IEnumerable<BusniessDocuments> busniessDocuments = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).busniessDocuments;
                model = (List<BusniessDocuments>)_busniessDocumentsRepository.SetBusniessDocumentsList(busniessDocuments);
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                IEnumerable<BusniessDocuments> busniessDocuments = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).busniessDocuments;
                model = (List<BusniessDocuments>)_busniessDocumentsRepository.SetBusniessDocumentsList(busniessDocuments);
            }
            else
            {
                model = new List<BusniessDocuments>();
            }

            return View("AllBusniessDocuments", model);
            //return View("BusniessUploadDocuments");
        }
        [HttpGet]
        public ViewResult AllBusniessDocuments()
        {
            int BusniessId;
            var model = new List<BusniessDocuments>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                IEnumerable<BusniessDocuments> busniessDocuments = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).busniessDocuments;
                model = (List<BusniessDocuments>)_busniessDocumentsRepository.SetBusniessDocumentsList(busniessDocuments);
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                IEnumerable<BusniessDocuments> busniessDocuments = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).busniessDocuments;
                model = (List<BusniessDocuments>)_busniessDocumentsRepository.SetBusniessDocumentsList(busniessDocuments);
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                IEnumerable<BusniessDocuments> busniessDocuments = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).busniessDocuments;
                model = (List<BusniessDocuments>)_busniessDocumentsRepository.SetBusniessDocumentsList(busniessDocuments);
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                IEnumerable<BusniessDocuments> busniessDocuments = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).busniessDocuments;
                model = (List<BusniessDocuments>)_busniessDocumentsRepository.SetBusniessDocumentsList(busniessDocuments);
            }
            else
            {
                model = new List<BusniessDocuments>();
            }

            return View("AllBusniessDocuments", model);
        }
        public ViewResult DeleteBusniessDocuments(int id)
        {
            _busniessDocumentsRepository.Delete(id);
            var updatedBusniessDocuments = _busniessDocumentsRepository.GetAllBusniessDocuments();

            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.busniessDocuments = (List<BusniessDocuments>)updatedBusniessDocuments;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusinessFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusinessFinanceBusniess.busniessDocuments = (List<BusniessDocuments>)updatedBusniessDocuments;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.busniessDocuments = (List<BusniessDocuments>)updatedBusniessDocuments;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.busniessDocuments = (List<BusniessDocuments>)updatedBusniessDocuments;
            }

            return View("AllBusniessDocuments", updatedBusniessDocuments);
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
                string filePath = null;
                String DocGuid=null;
                if(model.Document!=null)
                {
                    string UploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "BusniessDocument");
                    DocGuid = Guid.NewGuid().ToString();
                    uniqueFileName = DocGuid + "_" + model.Document.FileName;
                    filePath = Path.Combine(UploadsFolder, uniqueFileName);
                    model.Document.CopyTo(new FileStream(filePath,FileMode.Create));
                }

                int busniessId=0;
                int ApplicationId=0;
                String editAppType = HomeController.EditAppType;
                if (editAppType == "Asset finance")
                {
                    ApplicationId = AppAssetFinanceController.appID;
                    busniessId = AppAssetFinanceController.BusniessID;                   
                }
                else if (editAppType == "Business finance")
                {
                    ApplicationId = AppBusniessFinanceController.appID;
                    busniessId = AppBusniessFinanceController.BusniessID;
                }
                else if (editAppType == "Development finance")
                {
                    ApplicationId = AppDevelopmentFinanceController.appID;
                    busniessId = AppDevelopmentFinanceController.BusniessID;
                }
                else if (editAppType == "Property finance")
                {
                    ApplicationId = AppPropertyFinanceController.appID;
                    busniessId = AppPropertyFinanceController.BusniessID;
                }


                BusniessDocuments busniessDocuments = new BusniessDocuments
                {
                    AppId = ApplicationId,
                    BusniessId= busniessId,
                    DocumentName = model.DocumentName,
                    DocumentPath = filePath,
                    DocumentGuid= uniqueFileName
                };

                BusniessDocuments busniessDocuments1 = _busniessDocumentsRepository.Add(busniessDocuments);
                var updatedDocuments = _busniessDocumentsRepository.GetAllBusniessDocuments();


                return View("AllBusniessDocuments", updatedDocuments);
                //return View();
                //return View("AllBusniessDocuments");
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
                return View("BusniessUploadDocuments");
            }
        }

    }
}
