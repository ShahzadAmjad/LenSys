using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.AllApplications
{
    public interface IAllApplicationsRepository
    {
        AllApplications GetApplication(int KeyPrincipalsId);
        IEnumerable<AllApplications> GetAllApplications();
        AllApplications Add(AllApplications Applications);
        AllApplications Update(AllApplications ApplicationsChanges);
        AllApplications Delete(int ApplicationId);
    }
}
