﻿using System;
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
        public string Demolition { get; set; }
        public int MaterialsCost { get; set; }
        public int GasInstallation { get; set; }
        public int ElectricInstallation { get; set; }
        public int WaterInstallation { get; set; }

        public int LandScapingCost { get; set; }
        public int Labour { get; set; }
        public int CIL { get; set; }
        public string Insert1 { get; set; }
        public string Insert2 { get; set; }
        public string Insert3 { get; set; }
        public string Insert4 { get; set; }
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

        //FCA Regulations

        public string FCA_RegulatedLoan { get; set; }
        public string WillApplicantOrFamilyMemOwn40PercentOfSecurityatmortgageTime { get; set; }
        public string EverLivedinThisProperty { get; set; }

        //Accountant
        public string AccountantName { get; set; }
        public string AccountantCompany { get; set; }
        public int AccountantPhoneNo { get; set; }
        public string AccountantEmail { get; set; }
        public string AccountantAddress { get; set; }

        //Solicitor
        public string SolicitorName { get; set; }
        public string SolicitorCompany { get; set; }
        public int SolicitorPhoneNo { get; set; }
        public string SolicitorEmail { get; set; }
        public string SolicitorAddress { get; set; }
        public int SolicitorDXnumber { get; set; }
    }
}
