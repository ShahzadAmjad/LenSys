using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance
{
    public class MockAppPropertyFinanceSecurityDetailsRepository : IAppPropertyFinanceSecurityDetailsRepository
    {
        private List<AppPropertyFinanceSecurityDetails> _AppPropertyFinanceSecurityDetails;
        public MockAppPropertyFinanceSecurityDetailsRepository()
        {
            _AppPropertyFinanceSecurityDetails = new List<AppPropertyFinanceSecurityDetails>()
            {
                                //new AppPropertyFinanceSecurityDetails{
                                //    SecurityDetailsId=1,
                                //    SecurityType= "Residential ",
                                //    PropertyType="1 Bed Appartment",

                                //    AlreadyOwned="YES",
                                //    NameOfPropertyOwner = "John",
                                //    Tenure= 2,
                                //    YearsRemainingOnLeaseIfLeaseHold= 1,
                                //    PropertyValue= 5454,
                                //    OriginalPurchasePrice= 6000,
                                //    UseOfFunds="Security Money",
                                //    Rent=50,
                                //    HMO_MUFB="abc",
                                //    AddressForPropertyOfSecurity="Russia",
                                //    SecondLineAddress= "Cremlin",
                                //    City= "Moscow",
                                //    PostCode= 85000

                                //}
            };
        }
        public AppPropertyFinanceSecurityDetails Add(AppPropertyFinanceSecurityDetails appPropertyFinanceSecurityDetails)
        {
            if (_AppPropertyFinanceSecurityDetails.Count == 0)
            {
                appPropertyFinanceSecurityDetails.SecurityDetailsId = 1;

            }
            else
            {
                appPropertyFinanceSecurityDetails.SecurityDetailsId = _AppPropertyFinanceSecurityDetails.Max(e => e.SecurityDetailsId) + 1;
            }

            _AppPropertyFinanceSecurityDetails.Add(appPropertyFinanceSecurityDetails);
            return appPropertyFinanceSecurityDetails;
        }

        public IEnumerable<AppPropertyFinanceSecurityDetails> ClearSecurityDetailsList()
        {
            _AppPropertyFinanceSecurityDetails.Clear();
            return _AppPropertyFinanceSecurityDetails;
        }

        public AppPropertyFinanceSecurityDetails Delete(int AppPropertyFinanceSecurityDetailsId)
        {
            AppPropertyFinanceSecurityDetails appPropertyFinanceSecurityDetails = _AppPropertyFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == AppPropertyFinanceSecurityDetailsId);
            if (appPropertyFinanceSecurityDetails != null)
            {
                _AppPropertyFinanceSecurityDetails.Remove(appPropertyFinanceSecurityDetails);
            }
            return appPropertyFinanceSecurityDetails;
        }

        public IEnumerable<AppPropertyFinanceSecurityDetails> GetAllAppPropertyFinanceSecurityDetails()
        {
            return _AppPropertyFinanceSecurityDetails;
        }

        public AppPropertyFinanceSecurityDetails GetAppPropertysFinanceSecurityDetails(int AppPropertyFinanceSecurityDetailsId)
        {
            return _AppPropertyFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == AppPropertyFinanceSecurityDetailsId);
        }

        public IEnumerable<AppPropertyFinanceSecurityDetails> SetSecurityDetailsList(IEnumerable<AppPropertyFinanceSecurityDetails> SecurityDetailsList)
        {
            _AppPropertyFinanceSecurityDetails = (List<AppPropertyFinanceSecurityDetails>)SecurityDetailsList;
            return _AppPropertyFinanceSecurityDetails;
        }

        public AppPropertyFinanceSecurityDetails Update(AppPropertyFinanceSecurityDetails model)
        {
            AppPropertyFinanceSecurityDetails appPropertysFinanceSecurityDetails = _AppPropertyFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == model.SecurityDetailsId);
            if (appPropertysFinanceSecurityDetails != null)
            {
                appPropertysFinanceSecurityDetails.SecurityType = model.SecurityType;
                appPropertysFinanceSecurityDetails.PropertyType = model.PropertyType;
                appPropertysFinanceSecurityDetails.AlreadyOwned = model.AlreadyOwned;
                appPropertysFinanceSecurityDetails.NameOfPropertyOwner = model.NameOfPropertyOwner;
                appPropertysFinanceSecurityDetails.Tenure = model.Tenure;
                appPropertysFinanceSecurityDetails.YearsRemainingOnLeaseIfLeaseHold = model.YearsRemainingOnLeaseIfLeaseHold;

                appPropertysFinanceSecurityDetails.PropertyValue = model.PropertyValue;
                appPropertysFinanceSecurityDetails.OriginalPurchasePrice = model.OriginalPurchasePrice;
                appPropertysFinanceSecurityDetails.UseOfFunds = model.UseOfFunds;
                appPropertysFinanceSecurityDetails.Rent = model.Rent;
                appPropertysFinanceSecurityDetails.HMO_MUFB = model.HMO_MUFB;


                appPropertysFinanceSecurityDetails.AddressForPropertyOfSecurity = model.AddressForPropertyOfSecurity;
                appPropertysFinanceSecurityDetails.SecondLineAddress = model.SecondLineAddress;
                appPropertysFinanceSecurityDetails.City = model.City;
                appPropertysFinanceSecurityDetails.PostCode = model.PostCode;
            }
            return appPropertysFinanceSecurityDetails;
        }
    }
}
