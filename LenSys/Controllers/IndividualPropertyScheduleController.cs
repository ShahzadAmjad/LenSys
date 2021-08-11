using LenSys.Models.IndividualPropertySchedule;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Controllers
{
    public class IndividualPropertyScheduleController:Controller
    {
        private IPropertyScheduleRepository _propertyScheduleRepositry;

        public IndividualPropertyScheduleController(IPropertyScheduleRepository propertyScheduleRepository)
        {
            _propertyScheduleRepositry = propertyScheduleRepository;
        }
        public ViewResult Index()
        {
            //String name = "Default Index Page";
            //return name;

            //MockPropertyScheduleRepository mockPropertyScheduleRepository = new MockPropertyScheduleRepository();


            var model = _propertyScheduleRepositry.GetAllPropertySchedule();
            return View("AllProperties",model);
        }
        //[HttpGet]
        public ViewResult AllProperties()
        {
            var model = _propertyScheduleRepositry.GetAllPropertySchedule();
            return View("AllProperties", model);
        }

        [HttpGet]
        public ViewResult EditProperty(int id)
        {
 
            PropertySchedule model= _propertyScheduleRepositry.GetPropertySchedule(id);
            ViewBag.PageTitle = "Edit Property";
           
            return View("EditProperty",model);
        }
        [HttpPost]
        public IActionResult EditProperty(PropertySchedule model)
        {
            if (ModelState.IsValid)
            {
                PropertySchedule propertySchedule = _propertyScheduleRepositry.GetPropertySchedule(model.PropertyId);

                propertySchedule.PropertyId = model.PropertyId;
                propertySchedule.Owner = model.Owner;
                propertySchedule.PropertyAddress = model.PropertyAddress;
                propertySchedule.Lender = model.Lender;
                propertySchedule.PurchaseDate = model.PurchaseDate;
                propertySchedule.PurchasePrice = model.PurchasePrice;
                propertySchedule.OrigionalMortgageAmount = model.OrigionalMortgageAmount;
                propertySchedule.CurrentMarketValue = model.CurrentMarketValue;
                propertySchedule.OutstandingMortgage = model.OutstandingMortgage;
                propertySchedule.RemainingTerm = model.RemainingTerm;
                propertySchedule.TypeOfRate = model.TypeOfRate;
                propertySchedule.InterestRate = model.InterestRate;
                propertySchedule.RentPcm = model.RentPcm;
                propertySchedule.MortgagePcm = model.MortgagePcm;
                propertySchedule.LTV = model.LTV;
                propertySchedule.PropertyType = model.PropertyType;
                propertySchedule.PropertyDescription = model.PropertyDescription;
                propertySchedule.TypeOfTenancyLeaseASTBoth = model.TypeOfTenancyLeaseASTBoth;
                propertySchedule.RemainingTermOfLease = model.RemainingTermOfLease;

                //_propertyScheduleRepositry.Update(propertySchedule);

                
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return RedirectToAction("AllProperties");
                //return View("AllProperties");
            }

            return View("AllProperties");
        }
        public ViewResult DeleteProperty(int id)
        {
            //HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            //{
            //    Employee = _emplyeeRepositry.GetEmployee(id ?? 1),
            //    PageTitle = "Employee Details"
            //};
            // PropertySchedule model = _propertyScheduleRepositry.GetPropertySchedule(id);
            //ViewBag.PageTitle = "Delete Property";
            //ViewBag.Employee = model;
            //return View("PropertySchedule", model);

            _propertyScheduleRepositry.Delete(id);
            var RemainingProperties = _propertyScheduleRepositry.GetAllPropertySchedule();
            return View("AllProperties", RemainingProperties);
        }

        [HttpGet]
        public ViewResult PropertySchedule()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PropertySchedule(PropertySchedule propertySchedule)
        {
            if (ModelState.IsValid)
            {
                PropertySchedule newEmployee = _propertyScheduleRepositry.Add(propertySchedule);
                //return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return RedirectToAction("AllProperties");

                //return View("PropertySchedule");
            }

            return View("AllProperties");
        }
    }
}
