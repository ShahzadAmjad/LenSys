using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess;
using LenSys.Models.BusniessKeyPrincipals;
using LenSys.ViewModels.BusniessKeyPrincipals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class BusniessKeyPrincipalsController:Controller
    {
        private IKeyPrincipalsRepository _keyPrincipalsRepository;
        private IAppAssetFinanceBusniessRepository _appAssetFinanceBusniessRepository;
        private IAppBusniessFinanceBusniessRepository _appBusniessFinanceBusniessRepository;
        private IAppDevelopmentFinanceBusniessRepository _appDevelopmentFinanceBusniessRepository;
        private IAppPropertyFinanceBusniessRepository _appPropertyFinanceBusniessRepository;
        public BusniessKeyPrincipalsController(IKeyPrincipalsRepository keyPrincipalsRepository,
            IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository,
            IAppBusniessFinanceBusniessRepository appBusniessFinanceBusniessRepository,
            IAppDevelopmentFinanceBusniessRepository appDevelopmentFinanceBusniessRepository,
            IAppPropertyFinanceBusniessRepository appPropertyFinanceBusniessRepository)
        {
            _keyPrincipalsRepository = keyPrincipalsRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
            _appBusniessFinanceBusniessRepository = appBusniessFinanceBusniessRepository;
            _appDevelopmentFinanceBusniessRepository = appDevelopmentFinanceBusniessRepository;
            _appPropertyFinanceBusniessRepository = appPropertyFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            int BusniessId;
            var model = new List<KeyPrincipals>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                IEnumerable<KeyPrincipals> keyPrincipals = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                model = (List<KeyPrincipals>)_keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                IEnumerable<KeyPrincipals> keyPrincipals = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                model = (List<KeyPrincipals>)_keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                IEnumerable<KeyPrincipals> keyPrincipals = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                model = (List<KeyPrincipals>)_keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                IEnumerable<KeyPrincipals> keyPrincipals = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                model = (List<KeyPrincipals>)_keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }
            else
            {
                model = new List<KeyPrincipals>();
            }


            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = model;
            viewmodel.keyPrincipals = new KeyPrincipals();

            return View("AllKeyPrincipals", viewmodel);
        }
        public ViewResult AllKeyPrincipals()
        {
            //int BusniessId = AppAssetFinanceController.BusniessID;
            //if(BusniessId!=0)
            //{
            //    IEnumerable<KeyPrincipals> keyPrincipals = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
            //    _keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            //}           
            //var model = _keyPrincipalsRepository.GetAllKeyPrincipals();
            int BusniessId;
            var model = new List<KeyPrincipals>();

            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                IEnumerable<KeyPrincipals> keyPrincipals = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                model = (List<KeyPrincipals>)_keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                IEnumerable<KeyPrincipals> keyPrincipals = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                model = (List<KeyPrincipals>)_keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                IEnumerable<KeyPrincipals> keyPrincipals = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                model = (List<KeyPrincipals>)_keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                IEnumerable<KeyPrincipals> keyPrincipals = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                model = (List<KeyPrincipals>)_keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }
            else
            {
                model = new List<KeyPrincipals>();
            }

            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = model;
            viewmodel.keyPrincipals = new KeyPrincipals();
            return View("AllKeyPrincipals", viewmodel);
        }
        [HttpGet]
        public IActionResult AddKeyPrincipals()
        {
            KeyPrincipals keyPrincipals = new KeyPrincipals();
            return PartialView("_AddKeyPrincipalPartialView", keyPrincipals);
        }
        [HttpPost]
        public IActionResult AddKeyPrincipals(KeyPrincipals keyPrincipals1)
        {
            KeyPrincipals keyPrincipals = _keyPrincipalsRepository.Add(keyPrincipals1);
            var updatedKeyPrincipals = _keyPrincipalsRepository.GetAllKeyPrincipals();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
                //AppAssetFinanceIndividual appAssetFinanceIndividual = _appAssetFinanceIndividualRepository.GetIndividual(IndividualId);
                //appAssetFinanceIndividual.propertySchedule = (List<PropertySchedule>)updatedProperties;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusinessFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusinessFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }

            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = updatedKeyPrincipals;
            viewmodel.keyPrincipals = new KeyPrincipals();
            return RedirectToAction("AllKeyPrincipals", viewmodel);

        }
        [HttpGet]
        public ViewResult EditKeyPrincipals(int id)
        {
            //var model = _keyPrincipalsRepository.GetAllKeyPrincipals();
            //return View("AllKeyPrincipals", model);

            KeyPrincipals model = _keyPrincipalsRepository.GetKeyPrincipals(id);          
            return View("EditKeyPrincipals", model);
        }
        [HttpPost]
        public IActionResult EditKeyPrincipals(KeyPrincipals keyPrincipalsChange)
        {
            _keyPrincipalsRepository.Update(keyPrincipalsChange);
            var updatedKeyPrincipals = _keyPrincipalsRepository.GetAllKeyPrincipals();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipalsLst;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusinessFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusinessFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }

            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = updatedKeyPrincipals;
            viewmodel.keyPrincipals = new KeyPrincipals();
            return RedirectToAction("AllKeyPrincipals", viewmodel);

        }
        public ViewResult DeleteKeyPrincipal(int id)
        {
            _keyPrincipalsRepository.Delete(id);
            var updatedKeyPrincipals = _keyPrincipalsRepository.GetAllKeyPrincipals();

            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)RemainingProperties;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusinessFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusinessFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }

            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = updatedKeyPrincipals;
            viewmodel.keyPrincipals = new KeyPrincipals();

            return View("AllKeyPrincipals", viewmodel);
        }
        [HttpGet]
        public ViewResult KeyPrincipals()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KeyPrincipals(KeyPrincipals keyPrincipals1)
        {
           
                KeyPrincipals keyPrincipals = _keyPrincipalsRepository.Add(keyPrincipals1);

                var updatedKeyPrincipals = _keyPrincipalsRepository.GetAllKeyPrincipals();


            //int BusniessId = AppAssetFinanceController.BusniessID;
            //AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            //appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            int BusniessId;
            String editAppType = HomeController.EditAppType;

            if (editAppType == "Asset finance")
            {
                BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }

            else if (editAppType == "Business finance")
            {
                BusniessId = AppBusniessFinanceController.BusniessID;
                AppBusniessFinanceBusniess appBusinessFinanceBusniess = _appBusniessFinanceBusniessRepository.GetBusniess(BusniessId);
                appBusinessFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }
            else if (editAppType == "Development finance")
            {
                BusniessId = AppDevelopmentFinanceController.BusniessID;
                AppDevelopmentFinanceBusniess appDevelopmentFinanceBusniess = _appDevelopmentFinanceBusniessRepository.GetBusniess(BusniessId);
                appDevelopmentFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }
            else if (editAppType == "Property finance")
            {
                BusniessId = AppPropertyFinanceController.BusniessID;
                AppPropertyFinanceBusniess appPropertyFinanceBusniess = _appPropertyFinanceBusniessRepository.GetBusniess(BusniessId);
                appPropertyFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;
            }

            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = updatedKeyPrincipals;
                viewmodel.keyPrincipals = new KeyPrincipals();

                return RedirectToAction("AllKeyPrincipals", viewmodel);

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
                return View("AllKeyPrincipals");
            }
        }

    }
}
