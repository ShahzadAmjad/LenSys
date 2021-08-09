using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualPropertySchedule
{
    public class PropertySchedule
    {
        public string Property { get; set; }
        public string Owner { get; set; }
        public string PropertyAddress { get; set; }
        public string Lender { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PurchasePrice { get; set; }
        public int OrigionalMortgageAmount { get; set; }
        public int CurrentMarketValue { get; set; }
        public int OutstandingMortgage { get; set; }
        public int RemainingTerm { get; set; }
        public string TypeOfRate { get; set; }
        public int InterestRate { get; set; }
        public int RentPcm { get; set; }
        public int MortgagePcm { get; set; }
        public string LTV { get; set; }
        public string PropertyType { get; set; }
        public string PropertyDescription { get; set; }
        public int TypeOfTenancyLeaseASTBoth { get; set; }
        public int RemainingTermOfLease { get; set; }
    }
}
