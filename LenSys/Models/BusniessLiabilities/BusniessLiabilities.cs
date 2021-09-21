using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessLiabilities
{
    public class BusniessLiabilities
    {
        [Key]
        public int BusniessLiabilityId { get; set; }
        public string Lender { get; set; }
        public int OrigionalLoanAmount { get; set; }
        public int OutstandingBalance { get; set; }
        public int MonthlyPayment { get; set; }
        public string InitialTerm { get; set; }
        public string RemainingTerm { get; set; }
        public int Rate { get; set; }
        public string FixedOrVariable { get; set; }
        public string FixedTerm { get; set; }
        public int CommitmentTerm { get; set; }
        public int EarlyRepaymentCharge { get; set; }
        
    }
}
