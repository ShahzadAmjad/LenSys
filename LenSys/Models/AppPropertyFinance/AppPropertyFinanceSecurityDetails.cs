using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance
{
    public class AppPropertyFinanceSecurityDetails
    {
        //Id filed for development
        public int PropertyId { get; set; }
        public string SecurityType { get; set; }
        public string PropertyType { get; set; }
        public string AlreadyOwned { get; set; }
        public string NameOfPropertyOwner { get; set; }
        public int Tenure { get; set; }

        public int YearsRemainingOnLeaseIfLeaseHold { get; set; }
        public int PropertyValue { get; set; }
        public int OriginalPurchasePrice { get; set; }
        public string UseOfFunds { get; set; }
        public int Rent { get; set; }
        public string HMO_MUFB { get; set; }

        public string AddressForPropertyOfSecurity { get; set; }
        public string SecondLineAddress { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        

    }
}
