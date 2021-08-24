using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance
{
    public class AppBusniessFinanceSecurityDetails
    {
        public int SecurityDetailsId { get; set; }
        public string Notes { get; set; }
        public string LegalChargeOverProperty { get; set; }

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
    }
}
