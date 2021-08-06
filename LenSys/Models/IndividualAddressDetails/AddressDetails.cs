using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualAddressDetails
{
    public class AddressDetails
    {
        public string FirstLineAddress { get; set; }
        public string SecondLineAddress { get; set; }
        public string City { get; set; }      
        public int PostCode { get; set; }
        public DateTime DateMovedIn { get; set; }
        public string ResidentialStatus { get; set; }
        public int MarketValue { get; set; }
        public int OutstandingMortgageBalance { get; set; }
        public string LessThanThreeYears { get; set; }
        public string PreviousFirstLineAddress { get; set; }
        public string PreviousSecondLineAddress { get; set; }
        public string PreviousCity { get; set; }
        public int PreviousPostCode { get; set; }
        public DateTime PreviousDateMovedIn { get; set; }
    }
}
