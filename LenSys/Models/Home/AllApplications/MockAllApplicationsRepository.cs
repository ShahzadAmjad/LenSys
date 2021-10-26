using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppBusniessFinance;
using LenSys.Models.AppDevelopmentFinance;
using LenSys.Models.AppPropertyFinance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.AllApplications
{
    public class MockAllApplicationsRepository //:IAllApplicationsRepository
    {
        private IAppAssetFinanceRepository _appAssetFinanceRepository;
        private IAppBusniessFinanceRepository _appBusniessFinanceRepository;
        private IAppDevelopmentFinanceRepository _appDevelopmentFinanceRepository;
        private IAppPropertyFinanceRepository _appPropertyFinanceRepository;
        
        private List<AllApplications> _allApplications;

        public MockAllApplicationsRepository(IAppAssetFinanceRepository appAssetFinanceRepository, IAppBusniessFinanceRepository appBusniessFinanceRepository, IAppDevelopmentFinanceRepository appDevelopmentFinanceRepository, IAppPropertyFinanceRepository appPropertyFinanceRepository)
        {
            _allApplications = new List<AllApplications>()
            {
                //new AllApplications{AppID=1,Type="Individual", CompanyBusinessName="Busniess Finance" },
                //new AllApplications{AppID=2,Type="Busniess", CompanyBusinessName="Property Finance" },
                //new AllApplications{AppID=3,Type="Individual", CompanyBusinessName="Development Finance" }
            };
            _appAssetFinanceRepository = appAssetFinanceRepository;
            _appBusniessFinanceRepository = appBusniessFinanceRepository;
            _appDevelopmentFinanceRepository = appDevelopmentFinanceRepository;
            _appPropertyFinanceRepository = appPropertyFinanceRepository;
        }
        public AllApplications Add(AllApplications Applications)
        {
            Applications.AppID = _allApplications.Max(e => e.AppID) + 1;
            _allApplications.Add(Applications);
            return Applications;
        }

        public AllApplications Delete(int ApplicationId)
        {
            AllApplications keyPrincipals = _allApplications.FirstOrDefault(e => e.AppID == ApplicationId);
            if (keyPrincipals != null)
            {
                _allApplications.Remove(keyPrincipals);
            }
            return keyPrincipals;
        }

        public AppAssetFinance.AppAssetFinance DeleteAssetFinanceApplication(int ApplicationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AllApplications> GetAllApplications()
        {
            var appAssetFinanceApplication_AllAppFormat = _appAssetFinanceRepository.GetAllAppAssetFinance_AllApplication();
            var appBusinessFinanceApplication_AllAppFormat = _appBusniessFinanceRepository.GetAllAppBusniessFinance_AllApplication();
            var appDevelopmentFinanceApplication_AllAppFormat = _appDevelopmentFinanceRepository.GetAllAppDevelopmentFinance_AllApplication();
            var appPropertyFinanceApplication_AllAppFormat = _appPropertyFinanceRepository.GetAllAppPropertyFinance_AllApplication();

            _allApplications = ((List<AllApplications>)(appAssetFinanceApplication_AllAppFormat.Concat(appBusinessFinanceApplication_AllAppFormat)
                .Concat(appDevelopmentFinanceApplication_AllAppFormat)).Concat(appPropertyFinanceApplication_AllAppFormat));
            //AllApplications app = appAssetFinanceApplication.FirstOrDefault();
            return _allApplications;
        }

        public IEnumerable<AppAssetFinance.AppAssetFinance> GetAllAssetFinanceApplication()
        {
            throw new NotImplementedException();
        }

        public AllApplications GetApplication(int appId)
        {
            return _allApplications.FirstOrDefault(e => e.AppID == appId);
        }

        public AppAssetFinance.AppAssetFinance GetAssetFinanceApplication(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AllApplications> SearchAllApplications(string SearchAttribute, string SearchParam)
        {
            throw new NotImplementedException();
        }

        public AllApplications Update(AllApplications ApplicationsChanges)
        {
            AllApplications applications = _allApplications.FirstOrDefault(e => e.AppID == ApplicationsChanges.AppID);
            if (applications != null)
            {
                //keyPrincipals.KeyPrincipalsId = model.KeyPrincipalsId;
                //keyPrincipals.Title = model.Title;
                //keyPrincipals.FirstName = model.FirstName;
                //keyPrincipals.MiddleName = model.MiddleName;
                //keyPrincipals.Surname = model.Surname;
                //keyPrincipals.Position = model.Position;
                //keyPrincipals.PercentageShareholding = model.PercentageShareholding;
            }
            return applications;
        }
    }
}
