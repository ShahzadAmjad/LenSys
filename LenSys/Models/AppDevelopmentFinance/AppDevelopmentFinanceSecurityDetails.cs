using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance
{
    public class AppDevelopmentFinanceSecurityDetails
    {
        //Id filed for development
        public int SecurityDetailsId { get; set; }



        public string SecurityType { get; set; }
        public string DescriptionOfProperty { get; set; }
        public string PropertyCurrentUse { get; set; }
        public string NameOfPropertyOwner { get; set; }
        public int Tenure { get; set; }     
        public int YearsRemainingOnLeaseIfLeaseHold { get; set; }
        public string AddressForPropertyOfSecurity { get; set; }
        public string SecondLineAddress { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
    }
}
