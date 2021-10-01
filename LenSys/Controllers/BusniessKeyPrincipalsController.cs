using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
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
        public BusniessKeyPrincipalsController(IKeyPrincipalsRepository keyPrincipalsRepository, IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository)
        {
            _keyPrincipalsRepository = keyPrincipalsRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
        }
        public ViewResult Index()
        {
            int BusniessId = AppAssetFinanceController.BusniessID;
            if (BusniessId != 0)
            {
                IEnumerable<KeyPrincipals> keyPrincipals = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                _keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }

            var model = _keyPrincipalsRepository.GetAllKeyPrincipals();
            //return View("AllKeyPrincipals", model);    
            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = model;
            viewmodel.keyPrincipals = new KeyPrincipals();

            return View("AllKeyPrincipals", viewmodel);
        }
        public ViewResult AllKeyPrincipals()
        {
            int BusniessId = AppAssetFinanceController.BusniessID;

            if(BusniessId!=0)
            {
                IEnumerable<KeyPrincipals> keyPrincipals = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId).keyPrincipals;
                _keyPrincipalsRepository.SetKeyPrincipalsList(keyPrincipals);
            }
            

            var model = _keyPrincipalsRepository.GetAllKeyPrincipals();

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
            //if (ModelState.IsValid)
            {
                KeyPrincipals keyPrincipals = _keyPrincipalsRepository.Add(keyPrincipals1);

                var updatedKeyPrincipals = _keyPrincipalsRepository.GetAllKeyPrincipals();


                int BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;

                KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
                viewmodel._keyPrincipals = updatedKeyPrincipals;
                viewmodel.keyPrincipals = new KeyPrincipals();

                return RedirectToAction("AllKeyPrincipals", viewmodel);
            }

            //return View();
        }
        [HttpGet]
        public ViewResult EditKeyPrincipals(int id)
        {
            //var model = _keyPrincipalsRepository.GetAllKeyPrincipals();
            //return View("AllKeyPrincipals", model);

            KeyPrincipals model = _keyPrincipalsRepository.GetKeyPrincipals(id);
            ViewBag.PageTitle = "Edit Key Principal";

            return View("EditKeyPrincipals", model);
        }
        [HttpPost]
        public IActionResult EditKeyPrincipals(KeyPrincipals keyPrincipalsChange)
        {
            if (ModelState.IsValid)
            {
                _keyPrincipalsRepository.Update(keyPrincipalsChange);

                var updatedKeyPrincipalsLst = _keyPrincipalsRepository.GetAllKeyPrincipals();
                
                int BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipalsLst;

                

                return RedirectToAction("AllKeyPrincipals", updatedKeyPrincipalsLst);
                //return View("AllKeyPrincipals");
            }

            return View();
        }
        public ViewResult DeleteKeyPrincipal(int id)
        {
            _keyPrincipalsRepository.Delete(id);
            var RemainingProperties = _keyPrincipalsRepository.GetAllKeyPrincipals();
            
            int BusniessId = AppAssetFinanceController.BusniessID;
            AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
            appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)RemainingProperties;

            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = RemainingProperties;
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
            if (ModelState.IsValid)
            {
                KeyPrincipals keyPrincipals = _keyPrincipalsRepository.Add(keyPrincipals1);

                var updatedKeyPrincipals = _keyPrincipalsRepository.GetAllKeyPrincipals();


                int BusniessId = AppAssetFinanceController.BusniessID;
                AppAssetFinanceBusniess appAssetFinanceBusniess = _appAssetFinanceBusniessRepository.GetBusniess(BusniessId);
                appAssetFinanceBusniess.keyPrincipals = (List<KeyPrincipals>)updatedKeyPrincipals;

                KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
                viewmodel._keyPrincipals = updatedKeyPrincipals;
                viewmodel.keyPrincipals = new KeyPrincipals();

                return RedirectToAction("AllKeyPrincipals", viewmodel);
            }

            return View();
        }

    }
}
