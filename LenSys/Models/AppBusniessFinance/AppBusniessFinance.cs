using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance
{
    public class AppBusniessFinance
    {
        //Loan Details
        public int LoanId { get; set; }
        public string TypeOfFinance { get; set; }
        public int AmountOfFinance { get; set; }
        public int RepaymentTermMonths { get; set; }
        public int BrokerFee { get; set; }
        public string SecurityOffered { get; set; }

        //Security Details
        public string Notes { get; set; }
        public string LegalOrNot { get; set; }

        public string SecurityType { get; set; }
        public string PropertyType { get; set; }
        public string NameOfPropertyOwner { get; set; }
        public int Tenure { get; set; }
        public int YearsRemainingOnLeaseIfLeaseHold { get; set; }
        public int PropertyValue { get; set; }
        public int OriginalPurchasePrice { get; set; }

        public string AddressForPropertyOfSecurity { get; set; }
        public string SecondLineAddress { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }

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

        
    }
}
