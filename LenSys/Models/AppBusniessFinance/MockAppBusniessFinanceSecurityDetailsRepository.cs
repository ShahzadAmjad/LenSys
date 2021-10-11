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
                                //new AppBusniessFinanceSecurityDetails{
                                //    SecurityDetailsId=1,
                                //    Notes="Security Property",
                                //    LegalChargeOverProperty="YES",
                                //    SecurityType= "Residential ",
                                //    PropertyType="1 Bed Appartment",
                                //    NameOfPropertyOwner = "John",
                                //    Tenure= 2,
                                //    YearsRemainingOnLeaseIfLeaseHold= 1,
                                //    PropertyValue= 5454,
                                //    OriginalPurchasePrice= 6000,
                                //    AddressForPropertyOfSecurity="Russia",
                                //    SecondLineAddress= "Cremlin",
                                //    City= "Moscow",
                                //    PostCode= 85000

                                //}
            };
        }
        public AppBusniessFinanceSecurityDetails Add(AppBusniessFinanceSecurityDetails appBusniessFinanceSecurityDetails)
        {
            if(_AppBusniessFinanceSecurityDetails.Count==0)
            {
                appBusniessFinanceSecurityDetails.SecurityDetailsId = 0;
                
            }
            else
            {
                appBusniessFinanceSecurityDetails.SecurityDetailsId = _AppBusniessFinanceSecurityDetails.Max(e => e.SecurityDetailsId) + 1;
            }
            
            _AppBusniessFinanceSecurityDetails.Add(appBusniessFinanceSecurityDetails);
            return appBusniessFinanceSecurityDetails;
        }

        public IEnumerable<AppBusniessFinanceSecurityDetails> ClearSecurityDetailsList()
        {
            _AppBusniessFinanceSecurityDetails.Clear();
            return _AppBusniessFinanceSecurityDetails;
        }

        public AppBusniessFinanceSecurityDetails Delete(int AppBusniessFinanceSecurityDetailsId)
        {
            AppBusniessFinanceSecurityDetails appBusniessFinanceSecurityDetails = _AppBusniessFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == AppBusniessFinanceSecurityDetailsId);
            if (appBusniessFinanceSecurityDetails != null)
            {
                _AppBusniessFinanceSecurityDetails.Remove(appBusniessFinanceSecurityDetails);
            }
            return appBusniessFinanceSecurityDetails;
        }

        public IEnumerable<AppBusniessFinanceSecurityDetails> GetAllAppBusniessFinanceSecurityDetails()
        {
            return _AppBusniessFinanceSecurityDetails;
        }

        public AppBusniessFinanceSecurityDetails GetAppBusniessFinanceSecurityDetails(int AppBusniessFinanceSecurityDetailsId)
        {
            return _AppBusniessFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == AppBusniessFinanceSecurityDetailsId);
        }

        public IEnumerable<AppBusniessFinanceSecurityDetails> SetSecurityDetailsList(IEnumerable<AppBusniessFinanceSecurityDetails> SecurityDetailsList)
        {
            _AppBusniessFinanceSecurityDetails = (List<AppBusniessFinanceSecurityDetails>)SecurityDetailsList;
            return _AppBusniessFinanceSecurityDetails;
        }

        public AppBusniessFinanceSecurityDetails Update(AppBusniessFinanceSecurityDetails model)
        {
            AppBusniessFinanceSecurityDetails appBusniessFinanceSecurityDetails = _AppBusniessFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == model.SecurityDetailsId);
            if (appBusniessFinanceSecurityDetails != null)
            {
                appBusniessFinanceSecurityDetails.Notes = model.Notes;
                appBusniessFinanceSecurityDetails.LegalChargeOverProperty = model.LegalChargeOverProperty;
                appBusniessFinanceSecurityDetails.SecurityType = model.SecurityType;
                appBusniessFinanceSecurityDetails.PropertyType = model.PropertyType;
                appBusniessFinanceSecurityDetails.NameOfPropertyOwner = model.NameOfPropertyOwner;
                appBusniessFinanceSecurityDetails.Tenure = model.Tenure;
                appBusniessFinanceSecurityDetails.YearsRemainingOnLeaseIfLeaseHold = model.YearsRemainingOnLeaseIfLeaseHold;

                appBusniessFinanceSecurityDetails.PropertyValue = model.PropertyValue;
                appBusniessFinanceSecurityDetails.OriginalPurchasePrice = model.OriginalPurchasePrice;
                appBusniessFinanceSecurityDetails.AddressForPropertyOfSecurity = model.AddressForPropertyOfSecurity;
                appBusniessFinanceSecurityDetails.SecondLineAddress = model.SecondLineAddress;
                appBusniessFinanceSecurityDetails.City = model.City;
                appBusniessFinanceSecurityDetails.PostCode = model.PostCode;

            }
            return appBusniessFinanceSecurityDetails;
        }
    }
}
