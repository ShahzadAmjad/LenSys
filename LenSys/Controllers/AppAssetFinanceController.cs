﻿using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.BusniessDetails;
using LenSys.Models.IndividualPersonalDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class AppAssetFinanceController : Controller
    {
        private IAppAssetFinanceRepository _appAssetFinanceRepository;
        private IAppAssetFinanceBusniessRepository _appAssetFinanceBusniessRepository;
        private IAppAssetFinanceIndividualRepository _appAssetFinanceIndividualRepository;

        public AppAssetFinanceController(IAppAssetFinanceRepository appAssetFinanceRepository, IAppAssetFinanceBusniessRepository appAssetFinanceBusniessRepository, IAppAssetFinanceIndividualRepository appAssetFinanceIndividualRepository)
        {
            _appAssetFinanceRepository = appAssetFinanceRepository;
            _appAssetFinanceBusniessRepository = appAssetFinanceBusniessRepository;
            _appAssetFinanceIndividualRepository = appAssetFinanceIndividualRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AppAssetFinance");
        }
        public IActionResult AddLead()
        {
            return RedirectToAction("Lead","Home");
        }
        public IActionResult AddBusniess()
        {
            AppAssetFinanceBusniess appAssetFinanceBusniess = new AppAssetFinanceBusniess();

            BusniessDetails busniessDetails = new BusniessDetails { CompanyBusniessName = "Temp" };
            appAssetFinanceBusniess.busniessDetails=busniessDetails;
             _appAssetFinanceBusniessRepository.Add(appAssetFinanceBusniess);

            AppAssetFinance appAssetFinance = new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();

            return View("AppAssetFinance", appAssetFinance);
            //return RedirectToAction("BusniessDetails", "BusniessDetails");
            //return View("AppAssetFinance");
        }
        public IActionResult AddIndividual()
        {

            //return RedirectToAction("PersonalDetails", "IndividualPersonalDetails");
            AppAssetFinanceIndividual appAssetFinanceIndividual = new AppAssetFinanceIndividual();
            PersonalDetails individualPersonalDetails = new PersonalDetails { FirstName = "Temp" };
            appAssetFinanceIndividual.personalDetails= individualPersonalDetails;
            _appAssetFinanceIndividualRepository.Add(appAssetFinanceIndividual);



            AppAssetFinance appAssetFinance = new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();
           
            return View("AppAssetFinance", appAssetFinance);
            //return RedirectToAction("BusniessDetails", "BusniessDetails");
            //return View("AppAssetFinance");
        }
        [HttpGet]
        public ViewResult AppAssetFinance()
        {
            AppAssetFinance appAssetFinance = new AppAssetFinance();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();
            //ViewData["SecurityDetailsList"] = _appBusniessFinanceSecurityDetails.GetAllAppBusniessFinanceSecurityDetails();
            return View("AppAssetFinance", appAssetFinance);


            //return View();
        }
        [HttpPost]
        public IActionResult AppAssetFinance(AppAssetFinance appAssetFinance)
        {
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.GetAllBusniess();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.GetAllIndividual();


            //if (ModelState.IsValid)
            //{
                AppAssetFinance appAssetFinance1=_appAssetFinanceRepository.Add(appAssetFinance);

            //}

            //AppAssetFinance 
            appAssetFinance = new AppAssetFinance();
            appAssetFinance.individuals = (List<AppAssetFinanceIndividual>)_appAssetFinanceIndividualRepository.ClearIndividualList();
            appAssetFinance.busniesses = (List<AppAssetFinanceBusniess>)_appAssetFinanceBusniessRepository.ClearBusniessList();
            //appAssetFinance.securityDetails = List;
            //return View("AppBusniessFinance", appBusniessFinance2);

            return View("AppAssetFinance", appAssetFinance);
            //return JavaScript(alert(""));
        }


    }
}
