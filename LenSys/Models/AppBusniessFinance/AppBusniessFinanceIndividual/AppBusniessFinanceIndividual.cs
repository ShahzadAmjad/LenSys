using LenSys.Models.IndividualAddressDetails;
using LenSys.Models.IndividualAsset;
using LenSys.Models.IndividualCreditHistory;
using LenSys.Models.IndividualEmploymentDetails;
using LenSys.Models.IndividualIncomeExpenditure;
using LenSys.Models.IndividualLiabilities;
using LenSys.Models.IndividualMonthlyExpenditure;
using LenSys.Models.IndividualPersonalDetails;
using LenSys.Models.IndividualPropertySchedule;
using LenSys.Models.IndividualUploadDocuments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual
{
    public class AppBusniessFinanceIndividual
    {
        [Key]
        public int IndividualId { get; set; }
        public PersonalDetails personalDetails { get; set; }
        public AddressDetails addressDetails { get; set; }
        public EmploymentDetails employmentDetails { get; set; }
        public MonthlyIncome monthlyIncome { get; set; }
        public MonthlyExpenditure monthlyExpenditure { get; set; }
        public Asset asset { get; set; }
        public Liabilities liabilities { get; set; }
        //Multiple Properties
        public List<PropertySchedule> propertySchedule { get; set; }
        public CreditHistory creditHistory { get; set; }
        public IndividualDocuments individualDocuments { get; set; }
    }
}
