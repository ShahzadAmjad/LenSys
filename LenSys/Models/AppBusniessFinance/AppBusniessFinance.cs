using LenSys.Models.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance
{
    public class AppBusniessFinance
    {
        //Loan Details
       [Key]
        public int BusniessFinId { get; set; }
        public Lead Lead { get; set; }

        public List<AppBusniessFinanceIndividual.AppBusniessFinanceIndividual> individuals { get; set; }
        public List<AppBusniessFinanceBusniess.AppBusniessFinanceBusniess> busniesses { get; set; }

        //public string ApplicationType { get; set; }
        public string TypeOfFinance { get; set; }
        public int AmountOfFinance { get; set; }
        public int RepaymentTermMonths { get; set; }
        public int BrokerFee { get; set; }
        public string SecurityOffered { get; set; }

        //Security Details
        public List<AppBusniessFinanceSecurityDetails> securityDetails { get; set; }

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
