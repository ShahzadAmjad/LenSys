using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance
{
    public class AppDevelopmentFinance
    {
        //Loan Details
        public int LoanId { get; set; }
        public int PurchasePrice { get; set; }
        public int MarketValueOfLand { get; set; }
        public int ConstructionCost { get; set; }
        public int TotalDevelopmentCost { get; set; }
        public int GrossDevelopmentValue { get; set; }
        public int LoanAmount { get; set; }
        public int LoanTermMonths { get; set; }
        public int AmountOfExistingLoanToBe { get; set; }
        public DateTime TargetCompletionDate { get; set; }
        public int SourceOfDeposit { get; set; }
        public int ExistStrategy { get; set; }

        //Security Details
        public IEnumerable<AppDevelopmentFinanceSecurityDetails> securityDetails { get; set; }


        //Construction Fees
        public int Demolition { get; set; }
        public int MaterialsCost { get; set; }
        public int GasInstallation { get; set; }
        public int ElectricInstallation { get; set; }
        public int WaterInstallation { get; set; }

        public int LandScapingCost { get; set; }
        public int Labour { get; set; }
        public int CIL { get; set; }
        public int Insert1 { get; set; }
        public int Insert2 { get; set; }
        public int Insert3 { get; set; }
        public int Insert4 { get; set; }
        public int StampDuty { get; set; }
        public int LegalFees { get; set; }
        public int OtherCostFinance { get; set; }
        public int TotalCosts { get; set; }

        //Selling Costs
        public int EstateAgentFees { get; set; }
        public int SellingCosts_LegalFees { get; set; }
        public string SellingCosts_Insert1 { get; set; }
        public string SellingCosts_Insert2 { get; set; }
        public int SellingCosts_Total { get; set; }

        //Project Timescales
        public DateTime Acquistion { get; set; }
        public DateTime PlainingPermission { get; set; }
        public DateTime PlainingConditions { get; set; }
        public DateTime StartConstruction { get; set; }
        public DateTime BuildingSignOff { get; set; }
        public DateTime SaleLetWholeBuilding { get; set; }

        //Project Timescales
        public string DetailsOfPlainingPermission { get; set; }
        public string DetailsOfBuildersContrators { get; set; }

        //FCA Regulations

        public string FCA_RegulatedLoan { get; set; }
        public string WillApplicantOrFamilyMemOwn40PercentOfSecurityatmortgageTime { get; set; }
        public string EverLivedinThisProperty { get; set; }
        public string Notes { get; set; }


    }
}
