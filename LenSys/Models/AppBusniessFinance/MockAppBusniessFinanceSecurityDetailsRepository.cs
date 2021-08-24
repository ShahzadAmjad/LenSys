using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance
{
    public class MockAppBusniessFinanceSecurityDetailsRepository : IAppBusniessFinanceSecurityDetailsRepository
    {
        private List<AppBusniessFinanceSecurityDetails> _AppBusniessFinanceSecurityDetails;

        public MockAppBusniessFinanceSecurityDetailsRepository()
        {
            _AppBusniessFinanceSecurityDetails = new List<AppBusniessFinanceSecurityDetails>()
            {
                                new AppBusniessFinanceSecurityDetails{
                                    SecurityDetailsId=1,
                                    Notes="Security Property",
                                    LegalChargeOverProperty="YES",
                                    SecurityType= "Residential ",
                                    PropertyType="1 Bed Appartment",
                                    NameOfPropertyOwner = "John",
                                    Tenure= 2,
                                    YearsRemainingOnLeaseIfLeaseHold= 1,
                                    PropertyValue= 5454,
                                    OriginalPurchasePrice= 6000,
                                    AddressForPropertyOfSecurity="Russia",
                                    SecondLineAddress= "Cremlin",
                                    City= "Moscow",
                                    PostCode= 85000
                                }
            };
        }
        public AppBusniessFinanceSecurityDetails Add(AppBusniessFinanceSecurityDetails appBusniessFinanceSecurityDetails)
        {
            throw new NotImplementedException();
        }

        public AppBusniessFinanceSecurityDetails Delete(int AppBusniessFinanceSecurityDetailsId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppBusniessFinanceSecurityDetails> GetAllAppBusniessFinanceSecurityDetails()
        {
            throw new NotImplementedException();
        }

        public AppBusniessFinanceSecurityDetails GetAppBusniessFinanceSecurityDetails(int AppBusniessFinanceSecurityDetailsId)
        {
            throw new NotImplementedException();
        }

        public AppBusniessFinanceSecurityDetails Update(AppBusniessFinanceSecurityDetails appBusniessFinanceSecurityDetailsChanges)
        {
            throw new NotImplementedException();
        }
    }
}
