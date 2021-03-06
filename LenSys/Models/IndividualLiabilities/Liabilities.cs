using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualLiabilities
{
    public class Liabilities
    {
        [Key]
        public int LiabilitiesId { get; set; }
        public int Overdraft { get; set; }
        public int ResidentialMortgage { get; set; }
        public int CarLoanHP { get; set; }
        public int PersonalLoan1 { get; set; }
        public int PersonalLoan2 { get; set; }
        public int PersonalLoan3 { get; set; }
        public int StoreCreditCard1 { get; set; }
        public int StoreCreditCard2 { get; set; }
        public int StoreCreditCard3 { get; set; }
        public int PersonalGuaranteesSigned { get; set; }
        public int Others { get; set; }
        public int TotalLiabilities { get; set; }  //D
        public int NetAssets { get; set; }  //C-D
    }
}
