﻿using LenSys.Models.AppPropertyFinance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class AppPropertyFinanceController : Controller
    {
        private IAppPropertyFinanceSecurityDetailsRepository _appPropertyFinanceSecurityDetails;
        private IAppPropertyFinanceRepository _appPropertyFinanceRepository;

        public AppPropertyFinanceController(IAppPropertyFinanceSecurityDetailsRepository appPropertyFinanceSecurityDetailsRepository, IAppPropertyFinanceRepository appPropertyFinanceRepository)
        {
            _appPropertyFinanceSecurityDetails = appPropertyFinanceSecurityDetailsRepository;
            _appPropertyFinanceRepository = appPropertyFinanceRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;
            return View("AppPropertyFinance");
        }

        [HttpGet]
        public IActionResult AddSecurityDetail()
        {

            AppPropertyFinanceSecurityDetails securityDetails = new AppPropertyFinanceSecurityDetails();
            return PartialView("_AddSecutityDetailPropertyPartialView", securityDetails);

            //return View("EditSecurityDetail", model);
        }
        [HttpPost]
        public IActionResult AddSecurityDetail(AppPropertyFinanceSecurityDetails securityDetails)
        {
            _appPropertyFinanceSecurityDetails.Add(securityDetails);
            //AppBusniessFinanceSecurityDetails securityDetails = new AppBusniessFinanceSecurityDetails();
            //return PartialView("_AddSecutityDetailBusniessPartialView", securityDetails);

            //ViewData["SecurityDetailsList"] = _appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            AppPropertyFinance appPropertyFinance = new AppPropertyFinance();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();

            return View("AppPropertyFinance", appPropertyFinance);
        }


        [HttpGet]
        public IActionResult EditSecurityDetail(int id)
        {


            AppPropertyFinanceSecurityDetails securityDetails = _appPropertyFinanceSecurityDetails.GetAppPropertysFinanceSecurityDetails(id);
            //return View("EditSecurityDetail",model);

            return PartialView("_EditSecurityDetailPropertyPartialView", securityDetails);

        }

        [HttpGet]
        public ViewResult AppPropertyFinance()
        {

            //ViewData["SecurityDetailsList"] = _appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            AppPropertyFinance appPropertyFinance = new AppPropertyFinance();
            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();

            return View("AppPropertyFinance");

            //return View();
        }
        [HttpPost]
        public IActionResult AppPropertyFinance(AppPropertyFinance appPropertyFinance)
        {

            appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();

            if (ModelState.IsValid)
            {
                AppPropertyFinance appPropertyFinance1 = _appPropertyFinanceRepository.Add(appPropertyFinance);

            }
            //appPropertyFinance.securityDetails = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            AppPropertyFinance appPropertyFinance2 = new AppPropertyFinance();
            var List = (List<AppPropertyFinanceSecurityDetails>)_appPropertyFinanceSecurityDetails.GetAllAppPropertyFinanceSecurityDetails();
            List.Clear();
            appPropertyFinance2.securityDetails = List;
            return View("AppPropertyFinance", appPropertyFinance2);
            
        }
    }
}
