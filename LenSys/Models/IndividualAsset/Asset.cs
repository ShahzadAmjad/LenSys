using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualAssetLiabilities
{
    public class Asset
    {
        public int Cash { get; set; }
        public int Shares { get; set; }
        public int LifePolicy { get; set; }
        public int PersonalDewellingHouse { get; set; }
        public int OtherInvestments { get; set; }
        public int TotalAssets { get; set; }//C
        //public int Overdraft { get; set; }
        //public int ResidentialMortgage { get; set; }
        //public int CarLoanHP { get; set; }
        //public int PersonalLoan1 { get; set; }
        //public int PersonalLoan2 { get; set; }
        //public int PersonalLoan3 { get; set; }
        //public int StoreCreditCard1 { get; set; }
        //public int StoreCreditCard2 { get; set; }
        //public int StoreCreditCard3 { get; set; }
        //public int PersonalGuaranteesSigned { get; set; }
        //public int Others { get; set; }
        //public int TotalLiabilities { get; set; }  //D
        //public int NetAssets { get; set; }  //C-D
    }
}
