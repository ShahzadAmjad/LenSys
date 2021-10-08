using LenSys.Models.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance
{
    public class AppPropertyFinance
    {

        //Loan Details
        [Key]
        public int LoanId { get; set; }
        public Lead Lead { get; set; }
        public List<AppPropertyFinanceIndividual.AppPropertyFinanceIndividual> individuals { get; set; }
        public List<AppPropertyFinanceBusniess.AppPropertyFinanceBusniess> busniesses { get; set; }

        //public string ApplicationType { get; set; }
        public string LoanPurpose { get; set; }
        public int LoanAmount { get; set; }
        public string RateType { get; set; }
        public string RepaymentType { get; set; }
        public int RepaymentTermMonths { get; set; }
        public DateTime TargetCompletionDate { get; set; }
        public int BrokerFee { get; set; }
        public int SourceOfDeposit { get; set; }

        //Security Details
        public List<AppPropertyFinanceSecurityDetails> securityDetails { get; set; }

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
