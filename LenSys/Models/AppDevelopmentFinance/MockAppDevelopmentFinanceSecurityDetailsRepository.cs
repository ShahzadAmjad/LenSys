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
                                new AppDevelopmentFinanceSecurityDetails{
                                    SecurityDetailsId=1,
                                    SecurityType= "Residential ",
                                    DescriptionOfProperty= "Residential Plot",
                                    PropertyCurrentUse="Abondon",
                                    NameOfPropertyOwner = "John",
                                    Tenure= 2,
                                    YearsRemainingOnLeaseIfLeaseHold= 1,
                                    AddressForPropertyOfSecurity="Russia",
                                    SecondLineAddress= "Cremlin",
                                    City= "Moscow",
                                    PostCode= 85000

                                }
            };
        }
        public AppDevelopmentFinanceSecurityDetails Add(AppDevelopmentFinanceSecurityDetails appDevelopmentFinanceSecurityDetails)
        {
            appDevelopmentFinanceSecurityDetails.SecurityDetailsId = _AppDevelopmentFinanceSecurityDetails.Max(e => e.SecurityDetailsId) + 1;
            _AppDevelopmentFinanceSecurityDetails.Add(appDevelopmentFinanceSecurityDetails);
            return appDevelopmentFinanceSecurityDetails;
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

        public AppDevelopmentFinanceSecurityDetails Update(AppDevelopmentFinanceSecurityDetails model)
        {
            AppDevelopmentFinanceSecurityDetails appDevelopmentFinanceSecurityDetails = _AppDevelopmentFinanceSecurityDetails.FirstOrDefault(e => e.SecurityDetailsId == model.SecurityDetailsId);
            if (appDevelopmentFinanceSecurityDetails != null)
            {
                //appBusniessFinanceSecurityDetails.KeyPrincipalsId = model.SecurityDetailsId;
                //appBusniessFinanceSecurityDetails.Title = model.Title;
                //appBusniessFinanceSecurityDetails.FirstName = model.FirstName;
                //appBusniessFinanceSecurityDetails.MiddleName = model.MiddleName;
                //appBusniessFinanceSecurityDetails.Surname = model.Surname;
                //appBusniessFinanceSecurityDetails.Position = model.Position;
                //appBusniessFinanceSecurityDetails.PercentageShareholding = model.PercentageShareholding;
            }
            return appDevelopmentFinanceSecurityDetails;
        }
    }
}
