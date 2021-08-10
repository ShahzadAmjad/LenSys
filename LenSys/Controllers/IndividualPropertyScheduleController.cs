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
        public ViewResult PropertySchedule()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PropertySchedule(PropertySchedule propertySchedule)
        {
            if (ModelState.IsValid)
            {
                //Employee newEmployee = _emplyeeRepositry.Add(employee);
                ////return View();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                return View("PropertySchedule");
            }

            return View();
        }
    }
}
