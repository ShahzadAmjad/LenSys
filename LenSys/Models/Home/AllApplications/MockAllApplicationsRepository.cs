using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.AllApplications
{
    public class MockAllApplicationsRepository : IAllApplicationsRepository
    {
        private List<AllApplications> _allApplications;

        public MockAllApplicationsRepository()
        {
            _allApplications = new List<AllApplications>()
            {
                                new AllApplications{AppID=1,Category="Individual", FinanceType="Busniess Finance" },
                                new AllApplications{AppID=2,Category="Busniess", FinanceType="Property Finance" },
                                new AllApplications{AppID=3,Category="Individual", FinanceType="Development Finance" }
            };              
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

        public IEnumerable<AllApplications> GetAllApplications()
        {
            return _allApplications;
        }

        public AllApplications GetApplication(int appId)
        {
            return _allApplications.FirstOrDefault(e => e.AppID == appId);
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
