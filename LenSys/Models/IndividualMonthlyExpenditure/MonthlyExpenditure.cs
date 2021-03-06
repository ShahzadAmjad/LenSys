using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualMonthlyExpenditure
{
    public class MonthlyExpenditure
    {
        [Key]
        public int MonthlyExpenditureId { get; set; }       
        public int MortgageRent { get; set; }
        public int LifeAssurancePension { get; set; }
        public int RatesCouncilTax { get; set; }
        public int WaterGasElectricityTelephoneBill { get; set; }
        public int HomeBuildingContentsInsurance { get; set; }
        public int TravelToWork { get; set; }
        public int PetrolCarMaintenance { get; set; }
        public int CarInsuranceRoadTax { get; set; }
        public int FoodAndClothing { get; set; }
        public int LoanHPCreditCardPayments { get; set; }
        public int EntertainmentSubscriptions { get; set; }
        public int OtherCostChristmisHolidays { get; set; }
        public int TotalExpenditure { get; set; }  //B
        public int MonthlyDisposableIncome { get; set; }  //A-B
    }
}
