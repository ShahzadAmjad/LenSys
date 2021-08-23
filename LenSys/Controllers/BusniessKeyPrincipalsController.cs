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
        public BusniessKeyPrincipalsController(IKeyPrincipalsRepository keyPrincipalsRepository)
        {
            _keyPrincipalsRepository = keyPrincipalsRepository;
        }
        public ViewResult Index()
        {
            var model = _keyPrincipalsRepository.GetAllKeyPrincipals();
            //return View("AllKeyPrincipals", model);    
            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = model;
            viewmodel.keyPrincipals = new KeyPrincipals();

            return View("AllKeyPrincipals", viewmodel);
        }
        public ViewResult AllKeyPrincipals()
        {
            var model = _keyPrincipalsRepository.GetAllKeyPrincipals();

            KeyPrincipalsCreateViewModel viewmodel = new KeyPrincipalsCreateViewModel();
            viewmodel._keyPrincipals = model;
            viewmodel.keyPrincipals = new KeyPrincipals();

            return View("AllKeyPrincipals", viewmodel);
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

                return RedirectToAction("AllKeyPrincipals", updatedKeyPrincipalsLst);
                //return View("AllKeyPrincipals");
            }

            return View();
        }

        public ViewResult DeleteKeyPrincipal(int id)
        {
            _keyPrincipalsRepository.Delete(id);
            var RemainingProperties = _keyPrincipalsRepository.GetAllKeyPrincipals();
            return View("AllKeyPrincipals", RemainingProperties);
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
                return RedirectToAction("AllKeyPrincipals", updatedKeyPrincipals);
            }

            return View();
        }

    }
}
