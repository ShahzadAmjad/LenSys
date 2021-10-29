using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance
{
    public class MockAppDevelopmentFinanceSecurityDetailsRepository : IAppDevelopmentFinanceSecurityDetailsRepository
    {
        private List<AppDevelopmentFinanceSecurityDetails> _AppDevelopmentFinanceSecurityDetails;
        public MockAppDevelopmentFinanceSecurityDetailsRepository()
        {
            _AppDevelopmentFinanceSecurityDetails = new List<AppDevelopmentFinanceSecurityDetails>()
            {
                                //new AppDevelopmentFinanceSecurityDetails{
                                //    SecurityDetailsId=1,
                                //    SecurityType= "Residential ",
                                //    DescriptionOfProperty= "Residential Plot",
                                //    PropertyCurrentUse="Abondon",
                                //    NameOfPropertyOwner = "John",
                                //    Tenure= 2,
                                //    YearsRemainingOnLeaseIfLeaseHold= 1,
                                //    AddressForPropertyOfSecurity="Russia",
                                //    SecondLineAddress= "Cremlin",
                                //    City= "Moscow",
                                //    PostCode= 85000

                                //}
            };
        }
        public AppDevelopmentFinanceSecurityDetails Add(AppDevelopmentFinanceSecurityDetails appDevelopmentFinanceSecurityDetails)
        {
            if (_AppDevelopmentFinanceSecurityDetails.Count == 0)
            {
                appDevelopmentFinanceSecurityDetails.SecurityDetailsId = 1;

            }
            else
            {
                appDevelopmentFinanceSecurityDetails.SecurityDetailsId = _AppDevelopmentFinanceSecurityDetails.Max(e => e.SecurityDetailsId) + 1;
            }

            
            _AppDevelopmentFinanceSecurityDetails.Add(appDevelopmentFinanceSecurityDetails);
            return appDevelopmentFinanceSecurityDetails;
        }

        public IEnumerable<AppDevelopmentFinanceSecurityDetails> ClearSecurityDetailsList()
        {
            _AppDevelopmentFinanceSecurityDetails.Clear();
            return _AppDevelopmentFinanceSecurityDetails;
        }

        public AppDevelopmentFinanceSecurityDetails Delete(int AppDevelopmentFinanceSecurityDetailsId)
        {
            AppDevelopmentFinanceSecurityDetails appDevelopmentFinanceSecurityDetails = _AppDevelopmentFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == AppDevelopmentFinanceSecurityDetailsId);
            if (appDevelopmentFinanceSecurityDetails != null)
            {
                _AppDevelopmentFinanceSecurityDetails.Remove(appDevelopmentFinanceSecurityDetails);
            }
            return appDevelopmentFinanceSecurityDetails;
        }

        public IEnumerable<AppDevelopmentFinanceSecurityDetails> GetAllAppDevelopmentFinanceSecurityDetails()
        {
            return _AppDevelopmentFinanceSecurityDetails;
        }

        public AppDevelopmentFinanceSecurityDetails GetAppDevelopmentFinanceSecurityDetails(int AppDevelopmentFinanceSecurityDetailsId)
        {
            return _AppDevelopmentFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == AppDevelopmentFinanceSecurityDetailsId);
        }

        public IEnumerable<AppDevelopmentFinanceSecurityDetails> SetSecurityDetailsList(IEnumerable<AppDevelopmentFinanceSecurityDetails> SecurityDetailsList)
        {
            _AppDevelopmentFinanceSecurityDetails = (List<AppDevelopmentFinanceSecurityDetails>)SecurityDetailsList;
            return _AppDevelopmentFinanceSecurityDetails;
        }

        public AppDevelopmentFinanceSecurityDetails Update(AppDevelopmentFinanceSecurityDetails model)
        {
            AppDevelopmentFinanceSecurityDetails appDevelopmentFinanceSecurityDetails = _AppDevelopmentFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == model.SecurityDetailsId);
            if (appDevelopmentFinanceSecurityDetails != null)
            {   
                appDevelopmentFinanceSecurityDetails.SecurityType = model.SecurityType;
                appDevelopmentFinanceSecurityDetails.DescriptionOfProperty = model.DescriptionOfProperty;
                appDevelopmentFinanceSecurityDetails.PropertyCurrentUse = model.PropertyCurrentUse;
                appDevelopmentFinanceSecurityDetails.NameOfPropertyOwner = model.NameOfPropertyOwner;
                appDevelopmentFinanceSecurityDetails.Tenure = model.Tenure;
                appDevelopmentFinanceSecurityDetails.YearsRemainingOnLeaseIfLeaseHold = model.YearsRemainingOnLeaseIfLeaseHold;
                appDevelopmentFinanceSecurityDetails.AddressForPropertyOfSecurity = model.AddressForPropertyOfSecurity;
                appDevelopmentFinanceSecurityDetails.SecondLineAddress = model.SecondLineAddress;
                appDevelopmentFinanceSecurityDetails.City = model.City;
                appDevelopmentFinanceSecurityDetails.PostCode = model.PostCode;
            }
            return appDevelopmentFinanceSecurityDetails;
        }
    }
}
