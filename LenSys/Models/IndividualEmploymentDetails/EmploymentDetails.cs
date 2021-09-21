using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualEmploymentDetails
{
    public class EmploymentDetails
    {
        public int EmploymentDetailsId { get; set; }
        public string EmploymentStatus { get; set; }
        public string EmploymentType { get; set; }
        public int GrossSalary { get; set; }
        public int NationalInsuranceNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public string EmployersName { get; set; }
        public int LatestEarnedIncomeYearOne { get; set; }
        public int LatestEarnedIncomeYearTwo { get; set; }
        public int LatestEarnedIncomeYearThree { get; set; }
        
    }
}
